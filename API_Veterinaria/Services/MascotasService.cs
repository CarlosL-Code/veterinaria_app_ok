using API_Veterinaria.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Veterinaria.Services
{
    public class MascotasService : IMascotasService
    {
        private readonly ApplicationDbContext _context;

        public MascotasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mascota>> GetMascotasAsync()
        {
            return await _context.Mascotas.ToListAsync();
        }

        public async Task<Mascota?> GetMascotaByIdAsync(int id)
        {
            return await _context.Mascotas.FindAsync(id);
        }

        public async Task<Mascota> CreateMascotaAsync(Mascota mascota)
        {
            try
            {
                _context.Mascotas.Add(mascota);
                await _context.SaveChangesAsync();
                return mascota;

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteMascotaAsync(int id)
        {
            var mascota = await GetMascotaByIdAsync(id);
            if (mascota == null)
            {
                return false;
            }
            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Mascota?> UpdateMascotaAsync(Mascota mascota)
        {
            var existingMascota = await GetMascotaByIdAsync(mascota.Id);
            if (existingMascota == null)
            {
                return null;
            }
            existingMascota.Name = mascota.Name;
            existingMascota.FechaNacimiento = mascota.FechaNacimiento;
            existingMascota.Propietario = mascota.Propietario;
            existingMascota.Email = mascota.Email;
            existingMascota.Celular = mascota.Celular;
            existingMascota.CategoriaId = mascota.CategoriaId;
            existingMascota.AvatarPath = mascota.AvatarPath;

            try
            {
                _context.Mascotas.Update(existingMascota);
                await _context.SaveChangesAsync();
                return existingMascota;
            }
            catch
            {
                return null;
            }
        }
    }
}
