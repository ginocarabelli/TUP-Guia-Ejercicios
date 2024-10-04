using EFWebApi.Data.Repositories;
using EFWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private ILibroRepository _repository;
        public LibrosController(LibroRepositories repository)
        {
            _repository = repository;
        }
        // GET: api/<LibrosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repository.Get(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        // POST api/<LibrosController>
        [HttpPost]
        public IActionResult Post([FromBody] Libro libro)
        {
            try
            {
                if (IsValid(libro))
                {
                    _repository.Create(libro);
                    return Ok("Libro insertado");
                }
                else
                {
                    return BadRequest("Los datos no son correctos");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        // PUT api/<LibrosController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Libro libro)
        {
            try
            {
                if (IsValid(libro))
                {
                    _repository.Update(libro);
                    return Ok("Libro editado");
                }
                else
                {
                    return BadRequest("Los datos no son correctos");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                var libro = _repository.Get(id);
                if(libro != null)
                {
                    _repository.Delete(id);
                    return Ok("Libro eliminado");
                }
                else
                {
                    return BadRequest("Este libro no existe");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        private bool IsValid(Libro value)
        {
            return !string.IsNullOrWhiteSpace(value.Isbn) && !string.IsNullOrWhiteSpace(value.Nombre) && !string.IsNullOrWhiteSpace(value.FechaPublicacion) && value.Autor != 0;
        }
    }
}
