using Microsoft.AspNetCore.Mvc;
using Problema4.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Problema4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> lst;
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lst);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            foreach(Product x in lst)
            {
                if (x.Codigo.Equals(id))
                {
                    return Ok(x);
                }
            }
            return BadRequest("No encontrado");
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product producto)
        {
            return Ok("Agregado correctamente");
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Product producto)
        {
            return Ok("Editado correctamente");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            foreach(Product x in lst)
            {
                if (x.Codigo.Equals(id))
                {
                    lst.RemoveAt(id + 1);
                }
            }
            return Ok("Eliminado correctamente");
        }
    }
}
