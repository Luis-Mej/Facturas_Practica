using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dtos;
using Dtos.FacturasDTOS;
using Dtos.ProductosDTOS;
using Sesion;

namespace ClientAPI
{
    public partial class Factura : Form
    {
        private List<FacturaDetDTO> productoCarrito;
        public Factura(List<FacturaDetDTO> productoEnCarrito)
        {
            InitializeComponent();
            this.productoCarrito = productoEnCarrito;
            Load += Factura_Load;
        }
        private async void Factura_Load(object? sender, EventArgs e)
        {
            await CargarProductosDelCarrito();
        }

        private async Task CargarProductosDelCarrito()
        {
            dgvDetalles.Columns.Clear();
            dgvDetalles.DataSource = null;
            dgvDetalles.AutoGenerateColumns = false;

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "IdProducto",
                Name = "IdProducto",
                Visible = false
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Nombre del Producto",
                Name = "NombreProducto",
                ReadOnly = true
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                Name = "PrecioUnitario",
                ReadOnly = true
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Name = "Cantidad",
                ReadOnly = true
            });

            dgvDetalles.DataSource = productoCarrito;

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal totalSubtotal = 0;
            decimal totalIVA = 0;
            decimal totalGeneral = 0;

            foreach (var item in productoCarrito)
            {

                decimal precio = item.PrecioUnitario;
                int cantidad = item.Cantidad ?? 0;

                decimal subtotal = precio * cantidad;
                decimal iva = subtotal * 0.15M;
                decimal total = subtotal + iva;

                totalSubtotal += subtotal;
                totalIVA += iva;
                totalGeneral += total;
            }

            txtSubTotal.Text = totalSubtotal.ToString("0.00");
            txtIva.Text = totalIVA.ToString("0.00");
            txtTotal.Text = totalGeneral.ToString("0.00");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar la compra?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (SesionActual.IdUsuario == null)
            {
                MessageBox.Show("Error: Usuario inválido");
                return;
            }

            var guardarFactura = new FacturaDTO();

            guardarFactura.FacturaCab = new FacturaCabDTO(txtCliente.Text, txtIdentificacion.Text, txtTelefono.Text, txtEmail.Text, DateTime.Now, decimal.Parse(txtSubTotal.Text), decimal.Parse(txtIva.Text), decimal.Parse(txtTotal.Text), SesionActual.IdUsuario);

            guardarFactura.Detalles = productoCarrito;

            using HttpClient client = new HttpClient();
            string Url = "https://localhost:7037/api/Facturas";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionActual.Token);

            var json = JsonSerializer.Serialize(guardarFactura);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Url, content);


            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Factura guardada exitosamente");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar la factura");
            }
        }
    }
}
