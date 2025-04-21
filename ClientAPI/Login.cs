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
using Dtos;
using Dtos.UsuariosDTOS;
using Sesion;

namespace ClientAPI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioLoginDTO usuarioLoginDTO = new UsuarioLoginDTO(txtLogin.Text, txtContrasena.Text);

            using HttpClient client = new HttpClient();

            string Url = "https://localhost:7037/api/Login";
            var json = JsonSerializer.Serialize(usuarioLoginDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Url, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var parsed = JsonSerializer.Deserialize<ResponseBase<string>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                SesionActual.Token = parsed.Data;

                MessageBox.Show("Login exitoso");
                this.Hide();

                Producto producto = new Producto();
                producto.FormClosed += (s, args) => this.Close();
                producto.Show();
            }
            else
            {
                MessageBox.Show("Error al iniciar sesión");
            }
        }

        private void linkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registrar registrar = new Registrar();
            registrar.Show();
            this.Hide();
        }
    }
}
