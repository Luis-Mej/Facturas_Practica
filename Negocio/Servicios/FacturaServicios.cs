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

        public async Task<ResponseBase<List<FacturaVisualDTO>>> GetFactura()
        {
            try
            {
                var facturas = await _context.CabFacts
                    .Include(f => f.DetFacts)
                    .ToListAsync();

                var usuarios = await _context.Usuarios.ToListAsync();
                var productos = await _context.Productos.ToListAsync();

                var resultado = facturas.Select(f =>
                {
                    var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == f.IdUsuario);
                    var detalles = f.DetFacts.Select(d =>
                    {
                        var producto = productos.FirstOrDefault(p => p.Id == d.IdProducto);
                        var precio = producto?.Precio ?? 0;
                        var cantidad = d.Cantidad ?? 0;
                        var subTotal = precio * cantidad;

                        return new FactDetalleDTO(
                            producto?.Nombre ?? "Desconocido",
                            precio,
                            cantidad,
                            subTotal
                        );
                    }).ToList();

                    return new FacturaVisualDTO(
                        new FactCabeceraDTO(
                            f.NombreCliente,
                            f.Identificacion,
                            f.Telefono,
                            f.Email,
                            f.FechaCreacion,
                            f.SubTotal,
                            f.Iva,
                            f.Total,
                            usuario?.Nombre ?? "Desconocido"
                        ),
                        detalles
                    );
                }).ToList();

                return new ResponseBase<List<FacturaVisualDTO>>(200, "Facturas obtenidas", resultado);
            }
            catch (Exception ex)
            {
                return new ResponseBase<List<FacturaVisualDTO>>(400, "Error al obtener las facturas");
            }
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
            var factura = await _context.CabFacts
                .Include(f => f.DetFacts)
                .FirstOrDefaultAsync(x => x.IdFactura == id);

            if (factura == null)
            {
                return new ResponseBase<FacturaDTO>(400, "Factura no encontrada o no existe");
            }

            using var ts = await _context.Database.BeginTransactionAsync();
            try
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

             
                _context.DetFacts.RemoveRange(factura.DetFacts);
                await _context.SaveChangesAsync();

                
                var nuevosDetalles = facturaDTO.Detalles.Select(d => new DetFact(factura.IdFactura, d.IdProducto, d.Cantidad)).ToList();
                await _context.DetFacts.AddRangeAsync(nuevosDetalles);
                await _context.SaveChangesAsync();

                await ts.CommitAsync();
                return new ResponseBase<FacturaDTO>(200, "Factura actualizada");
            }
            catch (Exception)
            {
                await ts.RollbackAsync();
                return new ResponseBase<FacturaDTO>(400, "Error al actualizar la factura");
            }
        }

        public async Task<ResponseBase<string>> DeleteFactura (int id)
        {
            var factura = await _context.CabFacts.Include(x => x.DetFacts).FirstOrDefaultAsync(x => x.IdFactura == id);

            if (factura == null)
            {
                return new ResponseBase<string>(400, "Factura no encontrada o no existe");
            }

            using var ts = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.DetFacts.RemoveRange(factura.DetFacts);
                await _context.SaveChangesAsync();

                _context.CabFacts.Remove(factura);
                await _context.SaveChangesAsync();

                await ts.CommitAsync();
                return new ResponseBase<string>(200, "Factura eliminada");
            }
            catch (Exception)
            {
                await ts.RollbackAsync();
                return new ResponseBase<string>(400, "Error al eliminar la factura");
            }
        }
    }
}