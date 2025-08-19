using API_Veterinaria.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Veterinaria.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ApplicationDbContext _context;

        public CategoriasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> CreateCategoriaAsync(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return categoria;

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var categoria = await GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return false;
            }
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Categoria?> UpdateCategoriaAsync(Categoria categoria)
        {
            var existingCategoria = await GetCategoriaByIdAsync(categoria.Id);
            if (existingCategoria == null)
            {
                return null;
            }
            existingCategoria.Name = categoria.Name;
            existingCategoria.IsCategoria = categoria.IsCategoria;
            try
            {
                _context.Categorias.Update(existingCategoria);
                await _context.SaveChangesAsync();
                return existingCategoria;
            }
            catch
            {
                return null;
            }
        }




    }
}
