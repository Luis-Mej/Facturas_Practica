using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using Dtos.ProductosDTOS;
using Dtos.UsuariosDTOS;
using Microsoft.EntityFrameworkCore;
using Entidades.Context;
using Entidades.Models;

namespace Negocio.Servicios
{
    public class ProductosServicios
    {
        private readonly PracticaContext _context;

        public ProductosServicios(PracticaContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<List<ProductoDTO>>> GetProductosDTO()
        {
            var listaProductos = await _context.Productos.Where(x=> x.Estado =="A" && x.Stock!=0).Select(x => new ProductoDTO()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Precio = x.Precio,
                Stock = x.Stock,
            }).ToListAsync();

            return new ResponseBase<List<ProductoDTO>>(200, listaProductos);
        }

        public async Task<ResponseBase<ProductoDTO>> GetProductoPorId(int id)
        {
            var producto = await _context.Productos.Where(x => x.Id == id && x.Estado == "A").Select(x => new ProductoDTO()         
            {
                Nombre = x.Nombre,
                Precio = x.Precio,
                Stock = x.Stock,
            }).FirstOrDefaultAsync();
            if (producto == null)
            {
                return new ResponseBase<ProductoDTO>(400, "El producto no existe");
            }
            return new ResponseBase<ProductoDTO>(200, producto);
        }

        public async Task<ResponseBase<ProductoDTO>> PostProductosDTO(ProductoDTO productoDTO)
        {
            var productoExiste = await _context.Productos.FirstOrDefaultAsync(x => x.Nombre.ToUpper().Trim() == productoDTO.Nombre.ToUpper().Trim());
            if (productoExiste != null)
            {
                return new ResponseBase<ProductoDTO>(400, "Producto ya existe");
            }

            using var ts = await _context.Database.BeginTransactionAsync();
            {
                var productoRegistro = new Producto(productoDTO.Nombre, productoDTO.Precio, productoDTO.Stock, "A");


                _context.Productos.Add(productoRegistro);
                try
                {
                    await _context.SaveChangesAsync();
                    await ts.CommitAsync();
                }
                catch (Exception)
                {
                    await ts.RollbackAsync();
                    return new ResponseBase<ProductoDTO>(400, "Error al guardar el producto");
                }
            }
            return new ResponseBase<ProductoDTO>(200, "Producto ingresado");
        }

        public async Task<ResponseBase<ProductoDTO>> PutProductosDTO(ProductoDTO productoDTO)
        {
            var productoExistente = await _context.Productos.FindAsync(productoDTO.Id);
            if (productoExistente == null || productoExistente.Estado != "A")
            {
                return new ResponseBase<ProductoDTO>(400, "El producto no existe");
            }

            using var ts = await _context.Database.BeginTransactionAsync();
            {

                productoExistente.Nombre = productoDTO.Nombre;
                productoExistente.Precio = productoDTO.Precio;
                productoExistente.Stock = productoDTO.Stock;

                try
                {
                    await _context.SaveChangesAsync();
                    await ts.CommitAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(productoDTO.Id))
                    {
                        await ts.RollbackAsync();
                        return new ResponseBase<ProductoDTO>(400, "El producto no existe");
                    }
                    else
                    {
                        await ts.RollbackAsync();
                        throw;
                    }
                }
            }
                return new ResponseBase<ProductoDTO>(200, "Producto actualizado");
        }

        public async Task<ResponseBase<ProductoDTO>> DeleteProductosDTO(int id)
        {
            var productoExiste = await _context.Productos.FindAsync(id);
            if (productoExiste == null || productoExiste.Estado != "A")
            {
                return new ResponseBase<ProductoDTO>(400, "El producto no existe");
            }

            using var ts = await _context.Database.BeginTransactionAsync();
            {
                productoExiste.Estado = "I";
                await _context.SaveChangesAsync();
                await ts.CommitAsync();
                return new ResponseBase<ProductoDTO>(200, "Producto eliminado");
            }
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
