using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Veterinaria.Entities
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Precio { get; set; }

        [DisplayName("Disponible")]
        public bool IsActive { get; set; }

        // Cambié a plural para mejor convención
        public List<Categoria> Categorias { get; set; } = new();
        public List<Atencion> Atenciones { get; set; } = new();
    }
}
