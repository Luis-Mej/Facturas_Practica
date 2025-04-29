using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Shared.Dto.FacturasDTOS
{
    public class FacturasDTOs
    {
        public FacturasDTOs()
        {

        }
        public FacturasDTOs(string nombreCliente, DateTime? fechaCreacion, decimal? total)
        {
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
