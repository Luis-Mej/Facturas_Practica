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
            dgvDetalles.DataSource = productoCarrito;
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
