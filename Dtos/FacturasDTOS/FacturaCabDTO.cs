using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FacturasDTOS
{
    public class FacturaCabDTO
    {
        public FacturaCabDTO(string nombreCliente, string identificacion, string? telefono, string? email, DateTime? fechaCreacion, decimal subTotal, decimal? iva, decimal? total)
        {
            NombreCliente = nombreCliente;
            Identificacion = identificacion;
            Telefono = telefono;
            Email = email;
            FechaCreacion = fechaCreacion;
            SubTotal = subTotal;
            Iva = iva;
            Total = total;
        }

        public string NombreCliente { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public string? Telefono { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public DateTime? FechaCreacion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Total { get; set; }
    }
}
