using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Veterinaria.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Dato obligatorio")]
        [MaxLength(100)]
        [DisplayName("Nombre Categoria")]

        public string Name { get; set; }

        [DisplayName("Activa")]

        public bool IsCategoria { get; set; }

        public List<Servicio> Servicios { get; set; } = new();

    }
}
