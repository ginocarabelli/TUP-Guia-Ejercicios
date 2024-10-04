using EFWebAPI.Models;
using EFWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private IPeliculaService _service;
        public PeliculaController(IPeliculaService service)
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
                if (entity != null)
                {
                    return Ok(entity);
                }
                return NotFound("No se encontró esta película");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{genero}/{fechaA}/{fechaB}")]
        public IActionResult Get(int genero, int fechaA, int fechaB)
        {
            try
            {
                var entity = _service.GetByGeneroAndYear(genero, fechaA, fechaB);
                if (entity != null)
                {
                    return Ok(entity);
                }
                return NotFound("No se encontraron películas");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{fechaA}/{fechaB}")]
        public IActionResult Get(int fechaA, int fechaB)
        {
            try
            {   
                if(fechaA > fechaB)
                {
                    var entity = _service.GetByYear(fechaB, fechaA);
                    if (entity != null)
                    {
                        return Ok(entity);
                    }
                    return NotFound("No se encontraron películas");
                }
                else
                {
                    var entity = _service.GetByYear(fechaA, fechaB);
                    if (entity != null)
                    {
                        return Ok(entity);
                    }
                    return NotFound("No se encontraron películas");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Pelicula pelicula)
        {
            try
            {
                if (_service.Save(pelicula))
                {
                    return Ok("Pelicula guardada con éxito");
                }
                return BadRequest("No se pudo guardar la película");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Pelicula pelicula, int id)
        {
            try
            {
                if (_service.Update(pelicula, id))
                {
                    return Ok("Pelicula actualizada con éxito");
                }
                return BadRequest("No se pudo actualizar la película");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        if (_service.Delete(id))
        //        {
        //            return Ok("Pelicula eliminada con éxito");
        //        }
        //        return BadRequest("No se pudo eliminar la película");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
        [HttpDelete("{id}/{fechaBaja}")]
        public IActionResult Delete(int id, DateTime fechaBaja, [FromQuery] string? motivoBaja)
        {
            try
            {
                if (_service.DeleteByReason(id, fechaBaja, motivoBaja))
                {
                    return Ok("Pelicula eliminada con éxito");
                }
                return BadRequest("No se pudo eliminar la película");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
