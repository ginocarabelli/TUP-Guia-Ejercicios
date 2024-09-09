using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Problema1.Models;

namespace Problema1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        static readonly Fecha oFecha = new Fecha()
        {
            Numero = 9,
            Dia = "Lunes",
            Mes = "Septiembre",
            Año = 2024
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(oFecha);
        }
    }
}
