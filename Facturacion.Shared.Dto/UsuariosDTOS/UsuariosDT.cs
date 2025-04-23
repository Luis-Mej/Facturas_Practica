using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UsuariosDTOS
{
    public class UsuariosDT
    {
        public UsuariosDT()
        {
        }

        public UsuariosDT(int idUsuario, string nombre, string codigoUsuario)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            CodigoUsuario = codigoUsuario;
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoUsuario { get; set; } = string.Empty;
    }
}
