using EFWebApi.Models;
using EFWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private IPeliculaServices _service;
        public PeliculaController(IPeliculaServices service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                if(entity == null)
                {
                    return NotFound("No existe una película con este id");
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Pelicula pelicula)
        {
            try
            {
                if (_service.Save(pelicula))
                    return Ok("Creada");
                return BadRequest("No se pudo crear");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }

        [HttpPut("{id}-{estreno}")]
        public IActionResult Put(int id, bool estreno)
        {
            try
            {
                if (_service.Update(id, estreno))
                    return Ok("Editada");
                return BadRequest("No se pudo editar");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromQuery] string motivoBaja)
        {
            try
            {
                if (_service.Delete(id, motivoBaja))
                    return Ok("Eliminada");
                return BadRequest("No se pudo eliminar");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }
    }
}
