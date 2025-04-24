using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FacturasDTOS
{
    public class FactDetalleDTO
    {
        public FactDetalleDTO()
        {
        }

        public FactDetalleDTO(string nombreProducto, decimal precio, int? cantidad)
        {
            NombreProducto = nombreProducto;
            Precio = precio;
            Cantidad = cantidad;
        }

        public string NombreProducto { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int? Cantidad { get; set; }

    }
}
