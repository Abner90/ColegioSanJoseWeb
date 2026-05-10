using System.ComponentModel.DataAnnotations;

namespace ColegioSanJoseWeb.Models
{
    public class Materia
    {
        [Key]
        public int IdMateria { get; set; }

        [Required(ErrorMessage = "El nombre de la materia es obligatorio")]
        [Display(Name = "Nombre de la Materia")]
        public string NombreMateria { get; set; }

        [Required(ErrorMessage = "El nombre del docente es obligatorio")]
        [Display(Name = "Docente")]
        public string Docente { get; set; }

        // Relación con Expediente
        public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
    }
}