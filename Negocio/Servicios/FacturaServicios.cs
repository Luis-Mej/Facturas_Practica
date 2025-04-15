using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using Dtos.FacturasDTOS;
using Entidades.Context;
using Entidades.Models;

namespace Negocio.Servicios
{
    public class FacturaServicios
    {
        private readonly PracticaContext _context;
        public FacturaServicios(PracticaContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<FacturaDTO>> PostFactura(FacturaDTO facturaDTO)
        {
            using var ts = await _context.Database.BeginTransactionAsync();
            {
                var factura = new CabFact(facturaDTO.FacturaCab.NombreCliente,
                                          facturaDTO.FacturaCab.Identificacion,
                                          facturaDTO.FacturaCab.Telefono,
                                          facturaDTO.FacturaCab.Email,
                                          facturaDTO.FacturaCab.FechaCreacion,
                                          facturaDTO.FacturaCab.SubTotal,
                                          facturaDTO.FacturaCab.Iva,
                                          facturaDTO.FacturaCab.Total);
                await _context.CabFacts.AddAsync(factura);

                await _context.SaveChangesAsync();

                List<DetFact> detalles = new List<DetFact>();
                foreach (var item in facturaDTO.Detalles)
                {
                    var detalle = new DetFact(factura.IdFactura,item.IdProducto, item.Cantidad);
                    detalles.Add(detalle);
                }

                await _context.DetFacts.AddRangeAsync(detalles);
                await _context.SaveChangesAsync();

                try
                {
                    
                    await ts.CommitAsync();
                }

                catch (Exception)
                {
                    await ts.RollbackAsync();
                    return new ResponseBase<FacturaDTO>(400, "Error al guardar la factura");
                }
            }
            return new ResponseBase<FacturaDTO>(200, "Factura guardada");
        }
    }
}
