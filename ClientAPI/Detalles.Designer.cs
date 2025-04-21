namespace ClientAPI
{
    partial class Detalles
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNombreProducto = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            panel1 = new Panel();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(121, 36);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Datos del Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 116);
            label2.Name = "label2";
            label2.Size = new Size(128, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del Producto :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 183);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 2;
            label3.Text = "Precio :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 232);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Stock :";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(213, 120);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(100, 23);
            txtNombreProducto.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(213, 175);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 5;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(213, 224);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 329);
            panel1.Name = "panel1";
            panel1.Size = new Size(372, 41);
            panel1.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Dock = DockStyle.Right;
            btnGuardar.Location = new Point(297, 0);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 41);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.Location = new Point(222, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // Detalles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 370);
            Controls.Add(panel1);
            Controls.Add(txtStock);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombreProducto);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Detalles";
            Text = "Detalles";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNombreProducto;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private Panel panel1;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}