using API_Veterinaria.Entities;
using API_Veterinaria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _service;

        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _service.GetCategoriasAsync();
            if (categorias == null || !categorias.Any())
            {
                return NotFound("No categories found.");
            }
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var categoria = await _service.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest("Category data is required.");
            }
            var createdCategoria = await _service.CreateCategoriaAsync(categoria);
            return CreatedAtAction(nameof(GetCategoriaById), new { id = createdCategoria.Id }, createdCategoria);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null || categoria.Id <= 0)
            {
                return BadRequest("Valid category data is required for update.");
            }
            var updatedCategoria = await _service.UpdateCategoriaAsync(categoria);
            if (updatedCategoria == null)
            {
                return NotFound($"Category with ID {categoria.Id} not found for update.");
            }
            return Ok(updatedCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var deleted = await _service.DeleteCategoriaAsync(id);
            if (!deleted)
            {
                return NotFound($"Category with ID {id} not found for deletion.");
            }
            return NoContent(); // 204 No Content
        }
    }


}
