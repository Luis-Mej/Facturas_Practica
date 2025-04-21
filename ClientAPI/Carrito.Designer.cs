namespace ClientAPI
{
    partial class Carrito
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
            btnVolver = new Button();
            btnCancelar = new Button();
            btnGenerarFact = new Button();
            dgvCarrito = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnVolver);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGenerarFact);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 353);
            panel1.Name = "panel1";
            panel1.Size = new Size(522, 40);
            panel1.TabIndex = 0;
            // 
            // btnVolver
            // 
            btnVolver.Dock = DockStyle.Left;
            btnVolver.Location = new Point(0, 0);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(86, 40);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver a los Productos";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.Location = new Point(351, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 40);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGenerarFact
            // 
            btnGenerarFact.Dock = DockStyle.Right;
            btnGenerarFact.Location = new Point(433, 0);
            btnGenerarFact.Name = "btnGenerarFact";
            btnGenerarFact.Size = new Size(89, 40);
            btnGenerarFact.TabIndex = 0;
            btnGenerarFact.Text = "Generar Factura";
            btnGenerarFact.UseVisualStyleBackColor = true;
            btnGenerarFact.Click += btnGenerarFact_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.Location = new Point(0, 0);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new Size(522, 353);
            dgvCarrito.TabIndex = 1;
            // 
            // Carrito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 393);
            Controls.Add(dgvCarrito);
            Controls.Add(panel1);
            Name = "Carrito";
            Text = "Carrito";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnVolver;
        private Button btnCancelar;
        private Button btnGenerarFact;
        private DataGridView dgvCarrito;
    }
}