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
            panel2 = new Panel();
            panel3 = new Panel();
            dgvDetalles = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtCliente = new TextBox();
            txtTelefono = new TextBox();
            txtIdentificacion = new TextBox();
            txtEmail = new TextBox();
            dtFecha = new DateTimePicker();
            btnImprimir = new Button();
            btnCancelar = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnImprimir);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 395);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 55);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtFecha);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(txtIdentificacion);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(txtCliente);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(526, 164);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvDetalles);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 164);
            panel3.Name = "panel3";
            panel3.Size = new Size(526, 231);
            panel3.TabIndex = 2;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Dock = DockStyle.Fill;
            dgvDetalles.Location = new Point(0, 0);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(526, 231);
            dgvDetalles.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 21);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente: ";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 92);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 2;
            label3.Text = "Telefono:";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(229, 24);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 4;
            label5.Text = "Fecha:";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(104, 21);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(100, 23);
            txtCliente.TabIndex = 5;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(104, 92);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 6;
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(104, 53);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(100, 23);
            txtIdentificacion.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(104, 124);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 8;
            // 
            // dtFecha
            // 
            dtFecha.Location = new Point(290, 21);
            dtFecha.Name = "dtFecha";
            dtFecha.Size = new Size(200, 23);
            dtFecha.TabIndex = 9;
            // 
            // btnImprimir
            // 
            btnImprimir.Dock = DockStyle.Right;
            btnImprimir.Location = new Point(451, 0);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 55);
            btnImprimir.TabIndex = 0;
            btnImprimir.Text = "Imprimir Factura";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.Location = new Point(376, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 55);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Factura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Factura";
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
        private TextBox txtIdentificacion;
        private TextBox txtTelefono;
        private TextBox txtCliente;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnCancelar;
        private Button btnImprimir;
    }
}