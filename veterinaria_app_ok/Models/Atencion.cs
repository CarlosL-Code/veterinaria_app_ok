using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veterinaria_app_ok.Models
{
    [Table("Atencion")]
    public class Atencion
    {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Fecha { get; set; }

        [MaxLength(5000)]
        public string? Observaciones { get; set; }

        [DisplayFormat(DataFormatString = "{0:c0}")]
        public int Total { get; set; }

        // Relación 1:N con Mascota
        [ForeignKey("MascotaId")]
        public int MascotaId { get; set; }
        public Mascota? Mascota { get; set; }

        [MaxLength(450), ForeignKey("Usuario")]
        [DisplayName("Usuario")]
        public string? UserId { get; set; } = null!;
        public virtual IdentityUser? Usuario { get; set; }

        // Relación muchos a muchos con Servicio
        public List<Servicio> Servicios { get; set; } = new List<Servicio>();
    }
}
