using API_Veterinaria.Entities;

namespace API_Veterinaria.Services
{
    public interface ICategoriasService
    {
        Task<Categoria> CreateCategoriaAsync(Categoria categoria);
        Task<bool> DeleteCategoriaAsync(int id);
        Task<Categoria?> GetCategoriaByIdAsync(int id);
        Task<List<Categoria>> GetCategoriasAsync();
        Task<Categoria?> UpdateCategoriaAsync(Categoria categoria);
    }
}