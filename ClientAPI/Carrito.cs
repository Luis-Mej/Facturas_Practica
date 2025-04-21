using Dtos.ProductosDTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientAPI
{
    public partial class Carrito : Form
    {
        private List<ProductoDTO> productoEnCarrito;
        public Carrito(List<ProductoDTO> productosSeleccionados)
        {
            InitializeComponent();
            productoEnCarrito = productosSeleccionados.Select(p => new ProductoDTO
            {
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock,
            }).ToList();

            CargarProductosEnCarrito();
        }

        private void CargarProductosEnCarrito()
        {
            dgvCarrito.Columns.Clear();
            dgvCarrito.DataSource = null;

            dgvCarrito.DataSource = productoEnCarrito;

            dgvCarrito.Columns["Id"].Visible = false;
            dgvCarrito.Columns["Nombre"].HeaderText = "Nombre";
            dgvCarrito.Columns["Precio"].HeaderText = "Precio";
            dgvCarrito.Columns["Stock"].HeaderText = "Stock";

            DataGridViewTextBoxColumn cantidadCol = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                Name = "Cantidad",
                ValueType = typeof(int),
                Width = 70,
            };

            dgvCarrito.Columns.Add(cantidadCol);
        }

        private void btnGenerarFact_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells["Cantidad"].Value == null || !int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Por favor, seleccione una cantidad válida para todos los productos.");
                    return;
                }

                int stock = Convert.ToInt32(row.Cells["Stock"].Value);
                if (cantidad > stock)
                {
                    MessageBox.Show($"La cantidad seleccionada para {row.Cells["Nombre"].Value} excede el stock disponible.");
                    return;
                }

                MessageBox.Show($"Producto: {row.Cells["Nombre"].Value}, Precio: {row.Cells["Precio"].Value}, Cantidad: {cantidad}");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            productoEnCarrito.Clear();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
