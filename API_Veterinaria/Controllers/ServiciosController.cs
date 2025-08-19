using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Veterinaria.Services;
using API_Veterinaria.Entities;

namespace API_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosService _service;

        public ServiciosController(IServiciosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicios()
        {
            var servicios = await _service.GetServiciosAsync();
            if (servicios == null || !servicios.Any())
            {
                return NotFound("No services found.");
            }
            return Ok(servicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicioById(int id)
        {
            var servicio = await _service.GetServicioByIdAsync(id);
            if (servicio == null)
            {
                return NotFound($"Service with ID {id} not found.");
            }
            return Ok(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServicio([FromBody] Servicio servicio)
        {
            if (servicio == null)
            {
                return BadRequest("Service data is required.");
            }
            var createdServicio = await _service.CreateServicioAsync(servicio);
            if (createdServicio == null)
            {
                return BadRequest("Could not create service.");
            }
            return CreatedAtAction(nameof(GetServicioById), new { id = createdServicio.Id }, createdServicio);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateServicio([FromBody] Servicio servicio)
        {
            if (servicio == null || servicio.Id <= 0)
            {
                return BadRequest("Valid service data is required for update.");
            }
            var updatedServicio = await _service.UpdateServicioAsync(servicio);
            if (updatedServicio == null)
            {
                return NotFound($"Service with ID {servicio.Id} not found for update.");
            }
            return Ok(updatedServicio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            var deleted = await _service.DeleteServicioAsync(id);
            if (!deleted)
            {
                return NotFound($"Service with ID {id} not found for deletion.");
            }
            return NoContent(); // 204 No Content
        }
    }
}
