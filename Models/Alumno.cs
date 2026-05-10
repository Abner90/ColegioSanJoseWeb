using System;
using System.ComponentModel.DataAnnotations;

namespace ColegioSanJoseWeb.Models
{
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
    }
}