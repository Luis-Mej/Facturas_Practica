﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dtos.ProductosDTOS;
using Negocio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Practica.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme) ]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosServicios _productoServicio;

        public ProductosController(ProductosServicios productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var resultado = await _productoServicio.GetProductosDTO();
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var resultado = await _productoServicio.GetProductoPorId(id);
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody] ProductoDTO productoDto)
        {
            var resultado = await _productoServicio.PostProductosDTO(productoDto);
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto([FromBody] ProductoDTO productoDto)
        {
            var resultado = await _productoServicio.PutProductosDTO(productoDto);
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var resultado = await _productoServicio.DeleteProductosDTO(id);
            return StatusCode(resultado.StatusCode, resultado);
        }
    }
}
