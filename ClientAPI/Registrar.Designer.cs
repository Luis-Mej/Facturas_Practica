namespace ClientAPI
{
    partial class Registrar
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
            txtNombre = new TextBox();
            txtContrasenia = new TextBox();
            txtConfirContrasenia = new TextBox();
            panel1 = new Panel();
            btnCancelar = new Button();
            btnGuardar = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 52);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre de Usuario: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 135);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 220);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 2;
            label3.Text = "Confirmar Contraseña:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(50, 88);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(258, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(50, 169);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PasswordChar = '*';
            txtContrasenia.Size = new Size(258, 23);
            txtContrasenia.TabIndex = 4;
            txtContrasenia.UseSystemPasswordChar = true;
            // 
            // txtConfirContrasenia
            // 
            txtConfirContrasenia.Location = new Point(50, 254);
            txtConfirContrasenia.Name = "txtConfirContrasenia";
            txtConfirContrasenia.PasswordChar = '*';
            txtConfirContrasenia.Size = new Size(258, 23);
            txtConfirContrasenia.TabIndex = 5;
            txtConfirContrasenia.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 353);
            panel1.Name = "panel1";
            panel1.Size = new Size(379, 35);
            panel1.TabIndex = 6;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.Location = new Point(229, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 35);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Dock = DockStyle.Right;
            btnGuardar.Location = new Point(304, 0);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 35);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // Registrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 388);
            Controls.Add(panel1);
            Controls.Add(txtConfirContrasenia);
            Controls.Add(txtContrasenia);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Registrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNombre;
        private TextBox txtContrasenia;
        private TextBox txtConfirContrasenia;
        private Panel panel1;
        private Button btnCancelar;
        private Button btnGuardar;
    }
}