using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Problema2.Models;

namespace Problema2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private static List<Moneda> lst = new List<Moneda>()
        {
            new Moneda("Peso Argentino", 1),
            new Moneda("Dolar", 180)
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lst);
        }
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            foreach(Moneda x in lst)
            {
                if (x.Nombre.Equals(nombre))
                {
                    return Ok(x);
                }
            }
            return NotFound("Moneda no registrada");
        }
        [HttpPost]
        public IActionResult Post([FromBody] Moneda m)
        {
            if(m == null || string.IsNullOrEmpty(m.Nombre))
            {
                return BadRequest("Datos incorrectos");
            }
            lst.Add(m);
            return Ok("Moneda agregada");
        }
    }
}
