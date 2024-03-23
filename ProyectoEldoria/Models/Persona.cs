using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ProyectoEldoria.Models
{
    public class Persona
    {
        [Key]
        public int Codigo { get; set; }
        [Required (ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El retrato es obligatorio")]
        public String Retrato { get; set; }
        [Required(ErrorMessage = "El origen es obligatorio")]
        public string Origen { get; set;}
    }

    
}
