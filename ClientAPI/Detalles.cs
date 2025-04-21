using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dtos.ProductosDTOS;
using System.Net.Http.Headers;
using System.Text.Json;
using Sesion;

namespace ClientAPI
{
    public partial class Detalles : Form
    {
        private ProductoDTO? EditarProducto;
        public Detalles(ProductoDTO? producto = null)
        {
            InitializeComponent();
            EditarProducto = producto;

            if(EditarProducto != null || producto != null)
            {
                if (EditarProducto == null || string.IsNullOrEmpty(EditarProducto.Nombre))
                {
                    MessageBox.Show("Error: El producto no tiene nombre válido para editar.");
                    this.Close();
                    return;
                }

                txtNombreProducto.Text = producto?.Nombre;
                txtPrecio.Text = producto?.Precio.ToString();
                txtStock.Text = producto?.Stock.ToString();

                txtNombreProducto.ReadOnly = true;
            }

            btnGuardar.Click -= btnGuardar_Click;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            try
            {
                int id = EditarProducto?.Id ?? 0;
                string nombre = txtNombreProducto.Text.Trim();
                decimal.TryParse(txtPrecio.Text, out decimal precio);
                int.TryParse(txtStock.Text, out int stock);

                if (string.IsNullOrEmpty(nombre) || precio <= 0 || stock < 0)
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente.");
                    return;
                }

                ProductoDTO producto = new ProductoDTO(id, nombre, precio, stock);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionActual.Token);

                    var json = JsonSerializer.Serialize(producto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage respuesta;

                    if (EditarProducto == null)
                    {
                        respuesta = await client.PostAsync("https://localhost:7037/api/Productos", content);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Producto guardado exitosamente.");
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar el producto.");
                        }
                    }
                    else if(EditarProducto != null)
                    {
                        respuesta = await client.PutAsync($"https://localhost:7037/api/Productos/{EditarProducto.Id}", content);

                        if (respuesta.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Producto actualizado exitosamente.");
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el producto.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
