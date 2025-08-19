using Microsoft.EntityFrameworkCore;
using API_Veterinaria.Entities; // Ajusta el namespace según tu estructura

namespace API_Veterinaria.Services
{
    public class ServiciosService : IServiciosService
    {
        private readonly ApplicationDbContext _context;

        public ServiciosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> GetServiciosAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicio?> GetServicioByIdAsync(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task<Servicio?> CreateServicioAsync(Servicio servicio)
        {
            try
            {
                _context.Servicios.Add(servicio);
                await _context.SaveChangesAsync();
                return servicio;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteServicioAsync(int id)
        {
            var servicio = await GetServicioByIdAsync(id);
            if (servicio == null)
            {
                return false;
            }
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Servicio?> UpdateServicioAsync(Servicio servicio)
        {
            var existingServicio = await GetServicioByIdAsync(servicio.Id);
            if (existingServicio == null)
            {
                return null;
            }
            existingServicio.Nombre = servicio.Nombre;
            existingServicio.Descripcion = servicio.Descripcion;
            existingServicio.Precio = servicio.Precio;
            existingServicio.IsActive = servicio.IsActive;
            existingServicio.Categorias = servicio.Categorias; // Asegúrate de que las categorías estén correctamente asignadas
            // Si tienes más propiedades, agrégalas aquí

            try
            {
                _context.Servicios.Update(existingServicio);
                await _context.SaveChangesAsync();
                return existingServicio;
            }
            catch
            {
                return null;
            }
        }
    }
}
