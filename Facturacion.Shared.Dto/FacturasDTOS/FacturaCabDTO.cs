using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FacturasDTOS
{
    public class FacturaCabDTO
    {
        public FacturaCabDTO()
        {
        }
        public FacturaCabDTO(string nombreCliente, string identificacion, string telefono, string email, DateTime? fechaCreacion, decimal subTotal, decimal? iva, decimal? total, int? idUsuario)
        {

            NombreCliente = nombreCliente;
            Identificacion = identificacion;
            Telefono = telefono;
            Email = email;
            FechaCreacion = fechaCreacion;
            SubTotal = subTotal;
            Iva = iva;
            Total = total;
            IdUsuario = idUsuario;
        }
        public string NombreCliente { get; set; } = string.Empty;
        public string Identificacion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? FechaCreacion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Total { get; set; }
        public int? IdUsuario { get; set; }

    }
}
