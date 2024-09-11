using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Problema1.Models;

namespace Problema1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : ControllerBase
    {
        string[] diaSemana;
        public FechaController()
        {
             diaSemana = ["dom", "lun", "mar", "mie", "jue", "vie", "sab"];
        }

        [HttpGet]
        public IActionResult Get()
        {
            var fec = DateTime.Now;
            var fecha = new Fecha()
            {
                Numero = fec.Day,
                Dia = diaSemana[Convert.ToInt32(fec.DayOfWeek)],
                Mes = fec.Month,
                Año = fec.Year
            };

            return Ok(fecha);
        }
    }
}
