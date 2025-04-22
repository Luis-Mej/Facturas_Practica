using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Models;
using Dtos.UsuariosDTOS;
using System.Text.Json;
using Dtos;

namespace ClientAPI
{
    public partial class Registrar : Form
    { 
        public Registrar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;

            string nombre = txtNombre.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();
            string contraseniaConfirmar = txtConfirContrasenia.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contrasenia) || string.IsNullOrEmpty(contraseniaConfirmar))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                btnGuardar.Enabled = true;
                return;
            }
            if (contrasenia != contraseniaConfirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                btnGuardar.Enabled = true;
                return;
            }

            UsuarioDTOs usuarioDTOs = new UsuarioDTOs(nombre, contrasenia);
            using HttpClient client = new HttpClient();
            string Url = "https://localhost:7037/api/Usuarios";

            var json = JsonSerializer.Serialize(usuarioDTOs);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(Url, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync();
                var parsed = JsonSerializer.Deserialize<ResponseBase<string>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                MessageBox.Show("Usuario registrado exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario.");
            }
            btnGuardar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cancelar el registro del usuario", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
