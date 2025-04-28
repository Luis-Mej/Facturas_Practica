using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dtos.UsuariosDTOS
{
    public class UsuarioDTOs
    {
        public UsuarioDTOs()
        {
        }
        public UsuarioDTOs(int id, string nombre, string contrasenia)
        {
            Id = id;
            Nombre = nombre;
            Contrasenia = contrasenia;
        }
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;

    }
}
