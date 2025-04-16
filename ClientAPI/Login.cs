using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dtos.UsuariosDTOS;

namespace ClientAPI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioLoginDTO usuarioLoginDTO = new UsuarioLoginDTO(txtLogin.Text, txtContrasena.Text);

            HttpClient client = new HttpClient();

           string Url = "https://localhost:7030/api/Login";
            var json = JsonSerializer.Serialize(usuarioLoginDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(Url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Login exitoso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al iniciar sesión");
            }
        }
    }
}
