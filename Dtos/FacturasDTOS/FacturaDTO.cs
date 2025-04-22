using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FacturasDTOS
{
    public class FacturaDTO
    {
        public FacturaDTO()
        {
        }

        public FacturaDTO(FacturaCabDTO facturaCab, List<FacturaDetDTO> detalles)
        {
            FacturaCab = facturaCab;
            Detalles = detalles;
        }

        public FacturaCabDTO FacturaCab { get; set; } = null!;
        public List<FacturaDetDTO> Detalles { get; set; } = new List<FacturaDetDTO>();
    }
}
