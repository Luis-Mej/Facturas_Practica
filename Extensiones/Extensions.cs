using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensiones
{
    public static class Extensions
    {
        public static string GenerarNombreUsuario(this string nombresCompletos)
        {
            var nombres = nombresCompletos.Split(' ');

            if (nombres.Length > 2)
            {
                throw new ArgumentException("El nombre completo debe contener solo un nombre y un apellido.");
            }

            return nombres[0].Substring(0, 1).ToUpper() + nombres[1].ToUpper();
        }

        public static int CalcularValorIva(this decimal precio, decimal iva)
        {
            return (int)(precio * iva);
        }
    }
}
