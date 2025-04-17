using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FacturasDTOS
{
    public class FacturaVisualDTO
    {
        
        public FactCabeceraDTO Cabecera { get; set; }
        public List<FactDetalleDTO> Detalles { get; set; }
    }
}

