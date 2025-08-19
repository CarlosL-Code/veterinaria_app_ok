using API_Veterinaria.Entities;

namespace API_Veterinaria.Services
{
    public interface IAtencionService
    {
        Task<Atencion?> CreateAtencionAsync(Atencion atencion);
        Task<bool> DeleteAtencionAsync(int id);
        Task<Atencion?> GetAtencionByIdAsync(int id);
        Task<List<Atencion>> GetAtencionesAsync();
        Task<Atencion?> UpdateAtencionAsync(Atencion atencion);
    }
}