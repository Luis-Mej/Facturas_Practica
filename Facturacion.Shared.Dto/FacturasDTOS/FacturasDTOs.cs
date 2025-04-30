using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.FacturasDTOS
{
    public class FacturasDTOs
    {
        public FacturasDTOs()
        {

        }

        public FacturasDTOs(int idFactura, string nombreCliente, DateTime? fechaCreacion, decimal? total)
        {
            IdFactura = idFactura;
            NombreCliente = nombreCliente;
            FechaCreacion = fechaCreacion;
            Total = total;
        }

        public int IdFactura { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public DateTime? FechaCreacion { get; set; }
        public decimal? Total { get; set; }
    }
}
