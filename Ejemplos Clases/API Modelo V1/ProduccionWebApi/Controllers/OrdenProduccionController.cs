using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Entities;
using ProduccionBack.Services;

namespace ProduccionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenProduccionController : ControllerBase
    {
        private IProduccionService service;

        public OrdenProduccionController()
        {
            service = new ProduccionService();
        }

        // GET: api/<OrdenProduccionController>
        [HttpGet("componentes")]
        public IActionResult Get()
        {
            return Ok(service.ConsultarComponentes());
        }

        [HttpGet("ordenes")] //servidor:puerto/api/OrdenProduccion/ordenes?fecha=''&estado=''
        public IActionResult GetOrdenes([FromQuery] DateTime? fecha, [FromQuery] string? estado)
        {
            
            try
            {
                var lst = service.ConsultarOrdenes(fecha, estado);
                if (lst.Count == 0)
                    return NotFound("No se encontraron órdenes de producción para los filtros indicados!");
                return Ok(lst);

            }
            catch (Exception)
            {
               return StatusCode(500, "No se pudieron consultar las ordenes de producción!");
            }
        }


        [HttpDelete("ordenes/{nro}")]
        public IActionResult DeleteOrden(int nro) 
        {
            try
            {
                if (service.CancelarOrden(nro))
                {
                    return Ok($"Orden de producción {nro} cancelada");
                }
                else
                {
                    return NotFound("Orden no encontrada o en un estado incorrecto");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }


        // POST api/<OrdenProduccionController>
        [HttpPost]
        public IActionResult Post([FromBody] OrdenProduccion orden)
        {
            try
            {
                if (orden == null)
                {
                    return BadRequest("Se esperaba una orden de producción completa");
                }
                if (service.RegistrarProduccion(orden))
                    return Ok("Orden registrada con éxito!");
                else
                    return StatusCode(500, "No se pudo registrar la orden!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente!");
            }
        }
    }
}
