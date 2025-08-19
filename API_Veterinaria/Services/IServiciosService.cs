using API_Veterinaria.Entities;

namespace API_Veterinaria.Services
{
    public interface IServiciosService
    {
        Task<Servicio?> CreateServicioAsync(Servicio servicio);
        Task<bool> DeleteServicioAsync(int id);
        Task<Servicio?> GetServicioByIdAsync(int id);
        Task<List<Servicio>> GetServiciosAsync();
        Task<Servicio?> UpdateServicioAsync(Servicio servicio);
    }
}