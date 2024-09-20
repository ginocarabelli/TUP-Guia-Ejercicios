using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Entities;
using ProduccionBack.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProduccionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private ArticleManager service;
        public ArticleController()
        {
            service = new ArticleManager();
        }
        // GET: api/<ArticleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lst = service.GetAll();
                if (lst == null)
                    return NotFound("No existen artículos");
                return Ok(lst);
            }
            catch (Exception)
            {
                return NotFound("No se encontraron artículos");
            }
        }

        // GET api/<ArticleController>/5
        [HttpGet("id")]
        public IActionResult Get([FromQuery] int id)
        {
            try
            {
                Article a = service.GetById(id);
                if (a == null)
                    return NotFound("No hay articulos con id 1");
                return Ok(a);
            }
            catch (Exception)
            {
                return StatusCode(500, "No se encontraron artículos con este id");
            }
        }

        // POST api/<ArticleController>
        [HttpPost]
        public IActionResult Post([FromBody] Article article)
        {
            try
            {
                if (article == null)
                    return NotFound("El artículo no puede ser nulo");
                if (service.Save(article))
                    return Ok("Artículo creado correctamente");
                return StatusCode(500, "Error al crear");
            }
            catch (Exception)
            {
                return NotFound("Error interno");
            }
        }

        // PUT api/<ArticleController>/5
        [HttpPut("articulo")]
        public IActionResult Put([FromBody] Article article)
        {
            try
            {
                if (article == null)
                    return NotFound("El artículo no puede ser nulo");
                if (service.Update(article))
                    return Ok("Artículo editado correctamente");
                return StatusCode(500, "Error al editar");
            }
            catch (Exception)
            {
                return NotFound("Error interno");
            }
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery]int id)
        {
            try
            {
                if (service.Delete(id))
                    return Ok("Artículo eliminado correctamente");
                return StatusCode(500, "Error al eliminar");
            }
            catch (Exception)
            {
                return NotFound("Error interno");
            }
        }
    }
}
