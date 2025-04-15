using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                                          facturaDTO.FacturaCab.Total,
                                          facturaDTO.FacturaCab.IdUsuario);
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

        public async Task<ResponseBase<FacturaDTO>> PutFacturasDTO(int id, FacturaDTO facturaDTO)
        {
            var factura = await _context.CabFacts.FirstOrDefaultAsync(x => x.IdFactura == id);

            if(factura == null)
            {
                return new ResponseBase<FacturaDTO>(400, "Factura no encontrada o no existe");
            }

            using var ts = await _context.Database.BeginTransactionAsync();
            {
                factura.NombreCliente = facturaDTO.FacturaCab.NombreCliente;
                factura.Identificacion = facturaDTO.FacturaCab.Identificacion;
                factura.Telefono = facturaDTO.FacturaCab.Telefono;
                factura.Email = facturaDTO.FacturaCab.Email;
                factura.FechaCreacion = facturaDTO.FacturaCab.FechaCreacion;
                factura.SubTotal = facturaDTO.FacturaCab.SubTotal;
                factura.Iva = facturaDTO.FacturaCab.Iva;
                factura.Total = facturaDTO.FacturaCab.Total;
                factura.IdUsuario = facturaDTO.FacturaCab.IdUsuario;

                _context.CabFacts.Update(factura);
                await _context.SaveChangesAsync();

                List<DetFact> detalles = new List<DetFact>();
                foreach (var item in facturaDTO.Detalles)
                {
                    var detalle = new DetFact(factura.IdFactura, item.IdProducto, item.Cantidad);
                    detalles.Add(detalle);
                }

                _context.DetFacts.UpdateRange(detalles);
                await _context.SaveChangesAsync();

                try
                {
                    await ts.CommitAsync();
                }
                catch (Exception)
                {
                    await ts.RollbackAsync();
                    return new ResponseBase<FacturaDTO>(400, "Error al actualizar la factura");
                }
            }
            return new ResponseBase<FacturaDTO>(200, "Factura actualizada");
        }
    }
}