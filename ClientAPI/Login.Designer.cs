namespace ClientAPI
{
    partial class Login
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
            txtLogin = new TextBox();
            txtContrasena = new TextBox();
            btnLogin = new Button();
            linkRegistro = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 44);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 104);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLogin
            // 
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Location = new Point(77, 62);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(211, 23);
            txtLogin.TabIndex = 2;
            // 
            // txtContrasena
            // 
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.Location = new Point(77, 122);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(211, 23);
            txtContrasena.TabIndex = 3;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Control;
            btnLogin.ForeColor = SystemColors.ControlText;
            btnLogin.Location = new Point(135, 182);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(93, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkRegistro
            // 
            linkRegistro.AutoSize = true;
            linkRegistro.Location = new Point(149, 221);
            linkRegistro.Name = "linkRegistro";
            linkRegistro.Size = new Size(59, 15);
            linkRegistro.TabIndex = 5;
            linkRegistro.TabStop = true;
            linkRegistro.Text = "Registrate";
            linkRegistro.LinkClicked += linkRegistro_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 261);
            Controls.Add(linkRegistro);
            Controls.Add(btnLogin);
            Controls.Add(txtContrasena);
            Controls.Add(txtLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtLogin;
        private TextBox txtContrasena;
        private Button btnLogin;
        private LinkLabel linkRegistro;
    }
}