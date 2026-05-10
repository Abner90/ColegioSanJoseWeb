using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColegioSanJoseWeb.Models
{
    public class Expediente
    {
        [Key]
        public int IdExpediente { get; set; }

        [Required]
        [Display(Name = "Alumno")]
        public int IdAlumno { get; set; }

        [Required]
        [Display(Name = "Materia")]
        public int IdMateria { get; set; }

        [Required(ErrorMessage = "La nota final es obligatoria")]
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10")]
        [Display(Name = "Nota Final")]
        public double NotaFinal { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }

        // Relaciones
        [ForeignKey("IdAlumno")]
        public virtual Alumno? Alumno { get; set; }

        [ForeignKey("IdMateria")]
        public virtual Materia? Materia { get; set; }
    }
}