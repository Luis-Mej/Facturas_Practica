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

        public ResponseBase<FacturaVisualDTO> GetFacturaById(int idFactura)
        {
            try
            {
                var facturas = from factCab in _context.CabFacts
                               join factDetalle in _context.DetFacts on factCab.IdFactura equals factDetalle.IdFactura
                               join producto in _context.Productos on factDetalle.IdProducto equals producto.Id
                               join usuario in _context.Usuarios on factCab.IdUsuario equals usuario.IdUsuario
                               where factCab.IdFactura == idFactura

                               select new
                               {
                                   factDetalle,
                                   factCab,
                                   producto,
                                   usuario
                               };

                FacturaVisualDTO facturaVisualDTO = new FacturaVisualDTO()
                {

                    Cabecera = new FactCabeceraDTO(facturas.FirstOrDefault().factCab.NombreCliente,
                                                   facturas.FirstOrDefault().factCab.Identificacion,
                                                   facturas.FirstOrDefault().factCab.Telefono,
                                                   facturas.FirstOrDefault().factCab.Email,
                                                   facturas.FirstOrDefault().factCab.FechaCreacion,
                                                   facturas.FirstOrDefault().factCab.SubTotal,
                                                   facturas.FirstOrDefault().factCab.Iva,
                                                   facturas.FirstOrDefault().factCab.Total,
                                                   facturas.FirstOrDefault().usuario.CodigoUsuario),
                    Detalles = facturas.Select(x => x.factDetalle).Select(d => new FactDetalleDTO()
                    {
                        Cantidad = d.Cantidad,
                        NombreProducto = _context.Productos.FirstOrDefault(p => p.Id == d.IdProducto).Nombre,
                        Precio = _context.Productos.FirstOrDefault(p => p.Id == d.IdProducto).Precio,
                    }).ToArray()

                };
                return new ResponseBase<FacturaVisualDTO>(200, "Facturas obtenidas", facturaVisualDTO);
            }
            catch (Exception)
            {
                return new ResponseBase<FacturaVisualDTO>(400, "Error al obtener las facturas");
            }
        }

        public async Task<ResponseBase<FacturaVisualDTO>> PostFactura(FacturaDTO facturaDTO)
        {
            FacturaVisualDTO facturaVisualDTO = new FacturaVisualDTO();
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
                    var detalle = new DetFact(factura.IdFactura, item.IdProducto, item.Cantidad);

                    var producto =  _context.Productos.Where(x => x.Id == item.IdProducto).FirstOrDefault();

                    if (producto.Stock == 0)
                    {
                        await ts.RollbackAsync();
                        return new ResponseBase<FacturaVisualDTO>(400, $"El producto: {producto.Nombre} no tiene stock");
                    }
                    else if ( item.Cantidad > producto.Stock)
                    {
                        await ts.RollbackAsync();
                        return new ResponseBase<FacturaVisualDTO>(400, $"La cantidad sobrepasa al stock de {producto.Nombre}");
                    }
                    producto.Stock -= item.Cantidad.GetValueOrDefault();

                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                    detalles.Add(detalle);
                }

                await _context.DetFacts.AddRangeAsync(detalles);
                await _context.SaveChangesAsync();

                try
                {

                    await ts.CommitAsync();
                    facturaVisualDTO = this.GetFacturaById(factura.IdFactura).Data;
                }

                catch (Exception)
                {
                    await ts.RollbackAsync();
                    return new ResponseBase<FacturaVisualDTO>(400, "Error al guardar la factura");
                }
            }
            return new ResponseBase<FacturaVisualDTO>(200, "Factura guardada", facturaVisualDTO);
        }
    }
}