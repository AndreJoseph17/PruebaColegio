using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class AlumnoGrado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlumnoGrado { get; set; }
        [Required]
        public int IdAlumno { get; set; }
        [Required]
        public int GradoId { get; set; }
        [Required]
        public string Seccion { get; set; }
    }
}
