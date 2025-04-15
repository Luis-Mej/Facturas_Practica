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

        //[HttpPost]

        //public async Task<IActionResult> PostFactura([FromBody] FacturaCabDTO facturaDto)
        //{
        //    var resultado = await _facturaServicio.PostFactura(facturaDto);
        //    return StatusCode(resultado.StatusCode, resultado);
        //}

    }
}
