using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace API_Veterinaria.Entities
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

            // Forzar nombre singular de tabla
            modelBuilder.Entity<Mascota>().ToTable("Mascota");
            modelBuilder.Entity<Categoria>().ToTable("Categoria"); // si aplica
            modelBuilder.Entity<Servicio>().ToTable("Servicio"); // si aplica
            modelBuilder.Entity<Atencion>().ToTable("Atencion"); // si aplica

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
