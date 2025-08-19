using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using veterinaria_app_ok.Models;

namespace veterinaria_app_ok.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación muchos a muchos entre Servicio y Categoria
            modelBuilder.Entity<Servicio>()
                .HasMany(s => s.Categorias)
                .WithMany(c => c.Servicios);

            // Relación muchos a muchos entre Atencion y Servicio
            modelBuilder.Entity<Atencion>()
                .HasMany(a => a.Servicios)
                .WithMany(s => s.Atenciones);


        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Atencion> Atenciones { get; set; }
    }
}
