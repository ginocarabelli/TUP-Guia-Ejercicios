using Microsoft.AspNetCore.Mvc;
using Problema4.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Problema4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> lst = new List<Product>()
        {
            new Product(1, "Coca cola", 1500.00),
            new Product(2, "Alfajor Rasta", 1500.00)
        };
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
            foreach(Product x in lst)
            {
                if (x.Codigo.Equals(producto.Codigo))
                {
                    return BadRequest("El código de este producto ya existe");
                }
            }
            lst.Add(producto);
            return Ok("Agregado correctamente");
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Product producto)
        {
            foreach (Product x in lst)
            {
                if (x.Codigo.Equals(producto.Codigo))
                {
                    x.Nombre = producto.Nombre;
                    x.Precio = producto.Precio;
                }
                else
                {
                    return BadRequest("No existe este producto");
                }
            }
            return Ok("Editado correctamente");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            var productToRemove = lst.RemoveAll(p => p.Codigo == codigo);
            if(productToRemove == null)
            {
                return BadRequest("Este producto no existe");
            }
            return Ok("Eliminado correctamente");
        }
    }
}
