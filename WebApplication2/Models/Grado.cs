using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Grado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdProfesor { get; set; }
    }
}
