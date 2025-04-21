using Dtos;
using Dtos.ProductosDTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sesion;
using System.Net.Http.Headers;

namespace ClientAPI
{
    public partial class Producto : Form
    {
        private List<ProductoDTO> listaProductos = new List<ProductoDTO>();
        private Dictionary<string, int> productoIds = new Dictionary<string, int>();

        public Producto()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            Load += Producto_Load;
        }

        private async void Producto_Load(object sender, EventArgs e)
        {
            await CargarProductos();
        }

        private async Task CargarProductos()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionActual.Token);
                var respuesta = await client.GetAsync("https://localhost:7037/api/Productos");

                if (respuesta.IsSuccessStatusCode)
                {
                    var json = await respuesta.Content.ReadAsStringAsync();
                    var resultado = JsonSerializer.Deserialize<ResponseBase<List<ProductoDTO>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (resultado != null && resultado.Data != null)
                    {
                        listaProductos = resultado.Data;

                        dgvProductos.Columns.Clear();

                        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                        {
                            Name = "Seleccionado",
                            HeaderText = "",
                            Width = 30
                        };
                        dgvProductos.Columns.Add(checkColumn);

                        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Nombre",
                            HeaderText = "Nombre"
                        });

                        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Precio",
                            HeaderText = "Precio"
                        });

                        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Stock",
                            HeaderText = "Stock"
                        });

                        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Id",
                            HeaderText = "Id",
                            Visible = false
                        });

                        dgvProductos.DataSource = new BindingList<ProductoDTO>(listaProductos);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener la lista de productos.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar productos desde la API.");
                }
            }
        }

        //private async Task<int?> ObtenerIdProductosPorNombre(string nombre)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionActual.Token);
        //        var respuesta = await client.GetAsync($"https://localhost:7037/api/Productos?nombre={Uri.EscapeDataString(nombre)}");

        //        if (respuesta.IsSuccessStatusCode)
        //        {
        //            var json = await respuesta.Content.ReadAsStringAsync();
        //            var resultado = JsonSerializer.Deserialize<ResponseBase<List<ProductoDTO>>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
        //            return resultado?.Data?.FirstOrDefault()?.Id;
        //        }
        //        return null;
        //    }
        //}

        private List<ProductoDTO> ObtenerProductosSeleccionados()
        {
            var seleccionados = new List<ProductoDTO>();

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                bool marcado = Convert.ToBoolean(fila.Cells["Seleccionado"].Value);
                if (marcado)
                {
                    if (fila.DataBoundItem is ProductoDTO producto)
                    {
                        seleccionados.Add(producto);
                    }
                }
            }

            return seleccionados;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            Detalles form = new Detalles();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CargarProductos();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is ProductoDTO productoElejido)
            {
                Detalles form = new Detalles(productoElejido);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await CargarProductos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para editar.");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is ProductoDTO productoElegido)
            {
                if (productoElegido.Id <= 0)
                {
                    MessageBox.Show("No se pudo determinar el ID del producto seleccionado.");
                    return;
                }

                if (MessageBox.Show($"¿Deseas eliminar el producto '{productoElegido.Nombre}'?", "Eliminar Producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnEliminar.Enabled = false;

                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionActual.Token);
                            var respuesta = await client.DeleteAsync($"https://localhost:7037/api/Productos/{productoElegido.Id}");

                            if (respuesta.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Producto eliminado exitosamente.");
                                await CargarProductos();
                            }
                            else
                            {
                                string errorMsg = await respuesta.Content.ReadAsStringAsync();
                                MessageBox.Show($"Error al eliminar el producto. Detalles: {errorMsg}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado al eliminar: {ex.Message}");
                    }
                    finally
                    {
                        btnEliminar.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
            }
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            var seleccionados = ObtenerProductosSeleccionados();

            if (seleccionados.Count == 0)
            {
                MessageBox.Show("No se han seleccionado productos.");
                return;
            }

            Carrito carritoForm = new Carrito(seleccionados);
            carritoForm.ShowDialog();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarProducto.Text.ToLower().Trim();

            var productosFiltrados = listaProductos.Where(p => p.Nombre.ToLower().Contains(filtro) || p.Precio.ToString().Contains(filtro) || p.Stock.ToString().Contains(filtro)).ToList();

            dgvProductos.DataSource = productosFiltrados;
        }
    }
}
