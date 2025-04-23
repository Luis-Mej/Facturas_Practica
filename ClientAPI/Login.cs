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

        private int ObtenerIdUsuarioDesdeToken(string token)
        {
            var partes = token.Split('.');
            if (partes.Length != 3) return 0;

            var payload = partes[1];
            var jsonBytes = Base64UrlDecode(payload);
            var jsonString = Encoding.UTF8.GetString(jsonBytes);

            using var doc = JsonDocument.Parse(jsonString);
            var root = doc.RootElement;

            if (root.TryGetProperty("idUsuario", out var idUsuario))
                return idUsuario.GetInt32();

            return 0;
        }

        private byte[] Base64UrlDecode(string input)
        {
            input = input.Replace('-', '+').Replace('_', '/');
            switch (input.Length % 4)
            {
                case 2: input += "=="; break;
                case 3: input += "="; break;
                case 0: break;
                default: throw new FormatException("Token inválido");
            }
            return Convert.FromBase64String(input);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioLoginDTO usuarioLoginDTO = new UsuarioLoginDTO
            {
                Nombre = txtLogin.Text,
                Contrasenia = txtContrasena.Text
            };


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
                SesionActual.IdUsuario = ObtenerIdUsuarioDesdeToken(parsed.Data);

                MessageBox.Show("ID de usuario extraído del token: " + SesionActual.IdUsuario);


                if (SesionActual.Token == null && SesionActual.IdUsuario ==0)
                {
                    MessageBox.Show("Error al iniciar sesión");
                    return;
                }
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
