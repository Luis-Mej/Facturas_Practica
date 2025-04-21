namespace ClientAPI
{
    partial class Factura
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
            btnImprimir = new Button();
            panel2 = new Panel();
            txtCajero = new TextBox();
            txtTotal = new TextBox();
            txtIva = new TextBox();
            txtSubTotal = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            dtFecha = new DateTimePicker();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtIdentificacion = new TextBox();
            txtCliente = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            dgvDetalles = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnVolver);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnImprimir);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 489);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 26);
            panel1.TabIndex = 0;
            // 
            // btnVolver
            // 
            btnVolver.Dock = DockStyle.Left;
            btnVolver.Location = new Point(0, 0);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(98, 26);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver al Carrito";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.Location = new Point(290, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(117, 26);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Dock = DockStyle.Right;
            btnImprimir.Location = new Point(407, 0);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(119, 26);
            btnImprimir.TabIndex = 0;
            btnImprimir.Text = "Imprimir Factura";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtCajero);
            panel2.Controls.Add(txtTotal);
            panel2.Controls.Add(txtIva);
            panel2.Controls.Add(txtSubTotal);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(dtFecha);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(txtIdentificacion);
            panel2.Controls.Add(txtCliente);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(526, 197);
            panel2.TabIndex = 1;
            // 
            // txtCajero
            // 
            txtCajero.Location = new Point(290, 168);
            txtCajero.Name = "txtCajero";
            txtCajero.Size = new Size(100, 23);
            txtCajero.TabIndex = 17;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(290, 129);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 16;
            // 
            // txtIva
            // 
            txtIva.Location = new Point(290, 92);
            txtIva.Name = "txtIva";
            txtIva.Size = new Size(100, 23);
            txtIva.TabIndex = 15;
            // 
            // txtSubTotal
            // 
            txtSubTotal.Location = new Point(290, 56);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.Size = new Size(100, 23);
            txtSubTotal.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(225, 170);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 13;
            label9.Text = "Cajero: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(229, 132);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 12;
            label8.Text = "Total:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(229, 92);
            label7.Name = "label7";
            label7.Size = new Size(25, 15);
            label7.TabIndex = 11;
            label7.Text = "Iva:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(229, 61);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 10;
            label6.Text = "SubTotal: ";
            // 
            // dtFecha
            // 
            dtFecha.Location = new Point(290, 21);
            dtFecha.Name = "dtFecha";
            dtFecha.Size = new Size(200, 23);
            dtFecha.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(104, 124);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 8;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(104, 89);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 7;
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(104, 56);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(100, 23);
            txtIdentificacion.TabIndex = 6;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(104, 18);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(100, 23);
            txtCliente.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(229, 24);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 4;
            label5.Text = "Fecha:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 132);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 92);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 2;
            label3.Text = "Telefono:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 56);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 1;
            label2.Text = "Identificación: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 24);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente: ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvDetalles);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 197);
            panel3.Name = "panel3";
            panel3.Size = new Size(526, 292);
            panel3.TabIndex = 2;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Dock = DockStyle.Fill;
            dgvDetalles.Location = new Point(0, 0);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(526, 292);
            dgvDetalles.TabIndex = 0;
            // 
            // Factura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 515);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Factura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Factura";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvDetalles;
        private DateTimePicker dtFecha;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtIdentificacion;
        private TextBox txtCliente;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnCancelar;
        private Button btnImprimir;
        private Label label6;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txtCajero;
        private TextBox txtTotal;
        private TextBox txtIva;
        private TextBox txtSubTotal;
        private Button btnVolver;
    }
}