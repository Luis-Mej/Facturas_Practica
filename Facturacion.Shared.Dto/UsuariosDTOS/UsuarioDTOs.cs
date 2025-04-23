using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dtos.UsuariosDTOS
{
    public class UsuarioDTOs
    {
        public UsuarioDTOs(string nombre, string contrasenia)
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
        }

        public string Nombre { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;

    }
}
