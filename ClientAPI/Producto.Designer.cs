namespace ClientAPI
{
    partial class Producto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregar = new Button();
            panel2 = new Panel();
            txtBuscarProducto = new TextBox();
            btnCarrito = new Button();
            panel3 = new Panel();
            dgvProductos = new DataGridView();
            btnCerrar = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnAgregar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 396);
            panel1.Name = "panel1";
            panel1.Size = new Size(672, 37);
            panel1.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Dock = DockStyle.Right;
            btnEliminar.Location = new Point(437, 0);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 37);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar P.";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Dock = DockStyle.Right;
            btnEditar.Location = new Point(512, 0);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(85, 37);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Actualizar P.";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Dock = DockStyle.Right;
            btnAgregar.Location = new Point(597, 0);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 37);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar P.";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtBuscarProducto);
            panel2.Controls.Add(btnCarrito);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(672, 25);
            panel2.TabIndex = 1;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Dock = DockStyle.Left;
            txtBuscarProducto.Location = new Point(0, 0);
            txtBuscarProducto.Multiline = true;
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(522, 25);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // btnCarrito
            // 
            btnCarrito.Dock = DockStyle.Right;
            btnCarrito.Location = new Point(561, 0);
            btnCarrito.Name = "btnCarrito";
            btnCarrito.Size = new Size(111, 25);
            btnCarrito.TabIndex = 0;
            btnCarrito.Text = "Agregar al carrito";
            btnCarrito.TextAlign = ContentAlignment.MiddleRight;
            btnCarrito.UseVisualStyleBackColor = true;
            btnCarrito.Click += btnCarrito_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvProductos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(672, 371);
            panel3.TabIndex = 2;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(672, 371);
            dgvProductos.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Dock = DockStyle.Left;
            btnCerrar.Location = new Point(0, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(92, 37);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar Sesión";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // Producto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 433);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Producto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvProductos;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregar;
        private Button btnCarrito;
        private TextBox txtBuscarProducto;
        private Button btnCerrar;
    }
}