using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FacturasDTOS
{
    public class FactCabeceraDTO
    {
        public FactCabeceraDTO()
        {
        }

        public FactCabeceraDTO(string nombreCliente, string identificacion, string telefono, string email, DateTime fechaCreacion, decimal subTotal, decimal iva, decimal total, string nombreUsuario)
        {
            NombreCliente = nombreCliente;
            Identificacion = identificacion;
            Telefono = telefono;
            Email = email;
            FechaCreacion = fechaCreacion;
            SubTotal = subTotal;
            Iva = iva;
            Total = total;
            NombreUsuario = nombreUsuario;
        }

        public string NombreCliente { get; set; } = string.Empty;
        public string Identificacion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
    }
}
