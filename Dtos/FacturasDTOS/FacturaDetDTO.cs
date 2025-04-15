using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FacturasDTOS
{
    public class FacturaDetDTO
    {
        public FacturaDetDTO(int idFactura, int idProducto, int? cantidad)
        {
            IdFactura = idFactura;
            IdProducto = idProducto;
            Cantidad = cantidad;
        }

        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
    }
}
