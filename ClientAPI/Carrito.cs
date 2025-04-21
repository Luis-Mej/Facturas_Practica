using Dtos.FacturasDTOS;
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
        private List<FacturaDetDTO> productoEnCarrito;
        public Carrito(List<FacturaDetDTO> productosSeleccionados)
        {
            InitializeComponent();
            productoEnCarrito = productosSeleccionados.Select(p => new FacturaDetDTO
            {
                IdProducto = p.IdProducto,
                Cantidad = p.Cantidad
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
            dgvCarrito.Columns["Stock"].Visible = false ;

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
            var factura = new Factura(productoEnCarrito);
            factura.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea cancelar esta compra?", "Cancelar", MessageBoxButtons.YesNo) ==DialogResult.No)
            {
                return;
            }

            productoEnCarrito.Clear();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
