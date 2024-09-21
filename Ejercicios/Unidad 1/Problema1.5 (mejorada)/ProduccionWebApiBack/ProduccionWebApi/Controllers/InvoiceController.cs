using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Domain;
using ProduccionBack.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProduccionWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class InvoiceController : ControllerBase
    {
        private BillsManager _service;

        public InvoiceController()
        {
            _service = new BillsManager();
        }
        // GET: api/<InvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<InvoiceController>/5
        [HttpGet("id")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                var article = _service.GetInvoiceById(id);
                if(article == null)
                {
                    return NotFound("No existe esta factura");
                }
                return Ok(article);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public IActionResult Post([FromBody] Invoice invoice)
        {
            try
            {
                if(invoice == null)
                {
                    return BadRequest("La factura no puede ser nula");
                }
                if (_service.Save(invoice) == false)
                    return StatusCode(500, "Error al crear factura");
                else 
                    return Ok("Factura creada");
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Invoice invoice)
        {
            try
            {
                if (invoice == null)
                {
                    return BadRequest("La factura no puede ser nula");
                }
                if (_service.Update(invoice) == false)
                    return StatusCode(500, "Error al editar factura");
                else
                    return Ok("Factura editada");
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_service.Delete(id) == false)
                    return StatusCode(500, "Error al eliminar factura");
                else
                    return Ok("Factura eliminada");
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
    }
}
