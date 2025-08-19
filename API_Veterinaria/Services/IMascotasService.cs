using API_Veterinaria.Entities;

namespace API_Veterinaria.Services
{
    public interface IMascotasService
    {
        Task<Mascota> CreateMascotaAsync(Mascota mascota);
        Task<bool> DeleteMascotaAsync(int id);
        Task<Mascota?> GetMascotaByIdAsync(int id);
        Task<List<Mascota>> GetMascotasAsync();
        Task<Mascota?> UpdateMascotaAsync(Mascota mascota);
    }
}