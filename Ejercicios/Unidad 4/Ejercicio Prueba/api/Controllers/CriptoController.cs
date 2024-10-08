using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcialWebApi.Models;
using ParcialWebApi.Repositories;

namespace ParcialWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriptoController : ControllerBase
    {
        private readonly ICriptoRepository _repo;
        public CriptoController(ICriptoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{categoria}")]
        public IActionResult Get(int categoria)
        {
            try
            {
                return Ok(_repo.GetByCat(categoria));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }
        [HttpPut]
        public IActionResult Put(string simbolo, DateTime fecha, double cotizacion)
        {
            try
            {
                if(_repo.Update(simbolo, fecha, cotizacion))
                    return Ok("Actualizado");
                return BadRequest("No se pudo actualizar");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_repo.Delete(id))
                    return Ok("Eliminado");
                return BadRequest("No se pudo eliminar");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }
    }
}
