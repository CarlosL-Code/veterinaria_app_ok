using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Veterinaria.Services;
using API_Veterinaria.Entities;

namespace API_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtencionController : ControllerBase
    {
        private readonly IAtencionService _service;

        public AtencionController(IAtencionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAtenciones()
        {
            var atenciones = await _service.GetAtencionesAsync();
            if (atenciones == null || !atenciones.Any())
            {
                return NotFound("No atenciones found.");
            }
            return Ok(atenciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtencionById(int id)
        {
            var atencion = await _service.GetAtencionByIdAsync(id);
            if (atencion == null)
            {
                return NotFound($"Atencion with ID {id} not found.");
            }
            return Ok(atencion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAtencion([FromBody] Atencion atencion)
        {
            if (atencion == null)
            {
                return BadRequest("Atencion data is required.");
            }
            var createdAtencion = await _service.CreateAtencionAsync(atencion);
            if (createdAtencion == null)
            {
                return BadRequest("Could not create atencion.");
            }
            return CreatedAtAction(nameof(GetAtencionById), new { id = createdAtencion.Id }, createdAtencion);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateAtencion([FromBody] Atencion atencion)
        {
            if (atencion == null || atencion.Id <= 0)
            {
                return BadRequest("Valid atencion data is required for update.");
            }
            var updatedAtencion = await _service.UpdateAtencionAsync(atencion);
            if (updatedAtencion == null)
            {
                return NotFound($"Atencion with ID {atencion.Id} not found for update.");
            }
            return Ok(updatedAtencion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtencion(int id)
        {
            var deleted = await _service.DeleteAtencionAsync(id);
            if (!deleted)
            {
                return NotFound($"Atencion with ID {id} not found for deletion.");
            }
            return NoContent(); // 204 No Content
        }
    }
}
