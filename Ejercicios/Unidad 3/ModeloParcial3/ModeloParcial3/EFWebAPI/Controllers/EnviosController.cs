using EFWebAPI.Models;
using EFWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private IEnviosService _service;
        public EnviosController(IEnviosService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] DateTime desde, [FromQuery] DateTime hasta)
        {
            try
            {
                if(desde == null)
                {
                    desde = DateTime.MinValue;
                }
                else if(hasta == null)
                {
                    hasta = DateTime.Now;
                }
                return Ok(_service.GetAll(desde, hasta));
            }
            catch(Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }
        [HttpPost]
        public IActionResult Post(TEnvio envio)
        {
            try
            {
                if(_service.Save(envio))
                {
                    return Ok("Creado");
                }
                return BadRequest("No se pudo crear");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_service.Delete(id))
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
