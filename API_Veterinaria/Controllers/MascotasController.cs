using API_Veterinaria.Entities;
using API_Veterinaria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        private readonly IMascotasService _service;

        public MascotasController(IMascotasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMascotas()
        {
            var mascotas = await _service.GetMascotasAsync();
            if (mascotas == null || !mascotas.Any())
            {
                return NotFound("No mascotas found.");
            }
            return Ok(mascotas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMascotasById(int id)
        {
            var mascota = await _service.GetMascotaByIdAsync(id);
            if (mascota == null)
            {
                return NotFound($"Mascota with ID {id} not found.");
            }
            return Ok(mascota);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMascotas([FromBody] Mascota mascota)
        {
            if (mascota == null)
            {
                return BadRequest("mascota data is required.");
            }
            var createdMascota = await _service.CreateMascotaAsync(mascota);
            return CreatedAtAction(nameof(GetMascotasById), new { id = createdMascota.Id }, createdMascota);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateMascota([FromBody] Mascota mascota)
        {
            if (mascota == null || mascota.Id <= 0)
            {
                return BadRequest("Valid mascota data is required for update.");
            }
            var updatedMascota = await _service.UpdateMascotaAsync(mascota);
            if (updatedMascota == null)
            {
                return NotFound($"Mascota with ID {mascota.Id} not found for update.");
            }
            return Ok(updatedMascota);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(int id)
        {
            var deleted = await _service.DeleteMascotaAsync(id);
            if (!deleted)
            {
                return NotFound($"Mascota with ID {id} not found for deletion.");
            }
            return NoContent(); // 204 No Content
        }
    }
}
