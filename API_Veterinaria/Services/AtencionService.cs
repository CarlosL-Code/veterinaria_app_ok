using API_Veterinaria.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Veterinaria.Services
{
    public class AtencionService : IAtencionService
    {
        private readonly ApplicationDbContext _context;

        public AtencionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Atencion>> GetAtencionesAsync()
        {
            return await _context.Atenciones.ToListAsync();
        }

        public async Task<Atencion?> GetAtencionByIdAsync(int id)
        {
            return await _context.Atenciones.FindAsync(id);
        }

        public async Task<Atencion?> CreateAtencionAsync(Atencion atencion)
        {
            try
            {
                _context.Atenciones.Add(atencion);
                await _context.SaveChangesAsync();
                return atencion;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAtencionAsync(int id)
        {
            var atencion = await GetAtencionByIdAsync(id);
            if (atencion == null)
            {
                return false;
            }
            _context.Atenciones.Remove(atencion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Atencion?> UpdateAtencionAsync(Atencion atencion)
        {
            var existingAtencion = await GetAtencionByIdAsync(atencion.Id);
            if (existingAtencion == null)
            {
                return null;
            }
            // Actualiza las propiedades necesarias
            existingAtencion.Fecha = atencion.Fecha;
            existingAtencion.Observaciones = atencion.Observaciones;
            existingAtencion.Total = atencion.Total;
            existingAtencion.MascotaId = atencion.MascotaId;
            existingAtencion.Mascota = atencion.Mascota; // Si necesitas actualizar la mascota relacionada
            existingAtencion.UserId = atencion.UserId;
            existingAtencion.Usuario = atencion.Usuario; // Si necesitas actualizar el usuario relacionado
            existingAtencion.Servicios = atencion.Servicios; // Actualiza la lista de servicios relacionados
            // Si tienes más propiedades, agrégalas aquí

            try
            {
                _context.Atenciones.Update(existingAtencion);
                await _context.SaveChangesAsync();
                return existingAtencion;
            }
            catch
            {
                return null;
            }
        }
    }
}
