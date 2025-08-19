using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Veterinaria.Entities
{
    public class Mascota
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Nombre Mascota")]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [DisplayName("Dueño")]
        public string Propietario { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Celular { get; set; }

        [ForeignKey("CategoriaId")]
        [DisplayName("Categoria Mascota")]
        public int CategoriaId { get; set; }

        //Virtual estamos indicando que  qie
        public virtual Categoria? Categoria { get; set; }

        [DisplayName("Imagen Mascota")]
        public string? AvatarPath { get; set; }
    }
}
