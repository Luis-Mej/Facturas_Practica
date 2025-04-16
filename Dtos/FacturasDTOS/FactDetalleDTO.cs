using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FacturasDTOS
{
    public class FactDetalleDTO
    {
        public string NombreProducto { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int? Cantidad { get; set; }

    }
}
