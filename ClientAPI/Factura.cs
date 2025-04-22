using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dtos.FacturasDTOS;
using Dtos.ProductosDTOS;

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

                decimal precio = item.IdProducto;
                int cantidad = item.Cantidad ?? 0;

                decimal subtotal = precio * cantidad ;
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
    }
}
