using Dtos.FacturasDTOS;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Servicios;

namespace Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class FacturasController : ControllerBase
    {
        private readonly FacturaServicios _facturaServicio;

        public FacturasController(FacturaServicios facturaServicio)
        {
            _facturaServicio = facturaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetFactura()
        {
            var resultado = await _facturaServicio.GetFactura();
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpPost]
        public async Task<IActionResult> PostFactura([FromBody] FacturaDTO facturaDto)
        {
            var resultado = await _facturaServicio.PostFactura(facturaDto);
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, [FromBody] FacturaDTO facturaDto)
        {
            var resultado = await _facturaServicio.PutFacturasDTO(id, facturaDto);
            return StatusCode(resultado.StatusCode, resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura([FromBody] int id)
        {
            var resultado = await _facturaServicio.DeleteFactura(id);
            return StatusCode(resultado.StatusCode, resultado);
        }
    }
}
