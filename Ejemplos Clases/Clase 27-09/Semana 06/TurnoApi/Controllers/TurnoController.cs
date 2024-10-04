using Microsoft.AspNetCore.Mvc;
using TurnoApi.Models;
using TurnoApi.Services;

namespace TurnoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : Controller
    {
        private readonly ITurnoService _turnoService;
        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_turnoService.GetAll());
        }
        [HttpPost]
        public IActionResult Post([FromBody] TTurno turno)
        {
            return Ok(_turnoService.Save(turno));
        }
        [HttpPut]
        public IActionResult Put([FromQuery]int id,[FromBody] TTurno turno)
        {
            return Ok(_turnoService.Update(turno,id));
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id, [FromQuery] string motivo)
        {
            return Ok(_turnoService.Delete(id,motivo));
        }
    }
}
