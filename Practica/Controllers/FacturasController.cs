using Dtos;
using Dtos.FacturasDTOS;
using Facturacion.Shared.Dto.FacturasDTOS;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Servicios;

namespace Practica.Controllers
{
    [Route("api/Facturas")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class FacturasController : ControllerBase
    {
        private readonly FacturaServicios _facturaServicio;

        public FacturasController(FacturaServicios facturaServicio)
        {
            _facturaServicio = facturaServicio;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult<ResponseBase<List<FacturasDTOs>>> GetFacturas()
        {
            var resultado = _facturaServicio.GetFacturas();
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetFactura(int id)
        {
            var resultado = _facturaServicio.GetFacturaById(id);
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpPost]
        public async Task<IActionResult> PostFactura([FromBody] FacturaDTO facturaDto)
        {
            var resultado = await _facturaServicio.PostFactura(facturaDto);
            return StatusCode(resultado.StatusCode, resultado);
        }
    }
}
