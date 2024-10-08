using EFWebApi.Models;
using EFWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CineController : ControllerBase
    {
        private ICineRepositories _repo;
        public CineController(ICineRepositories repo)
        {
            _repo = repo;
        }
        // GET: api/<CineController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/<CineController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _repo.GetById(id);
                if(entity != null)
                {
                    return Ok(entity);
                }
                else
                {
                    return NotFound();
                }
            } 
            catch(Exception) 
            { 
                return StatusCode(500, "Sos un pene"); 
            }
        }

        // POST api/<CineController>
        [HttpPost]
        public IActionResult Post([FromBody] Pelicula pelicula)
        {
            try
            {
                if (_repo.Save(pelicula))
                {
                    return Ok("Created");
                }
                else
                {
                    return BadRequest("Mal");
                }
            
            }
            catch (Exception)
            {
                return StatusCode(500, "Malardo");
            }
        }

        // DELETE api/<CineController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(_repo.Delete(id))
                {
                    return Ok("Eliminated");
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch(Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
