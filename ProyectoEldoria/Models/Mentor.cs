using System.ComponentModel.DataAnnotations;

namespace ProyectoEldoria.Models
{
    public class Mentor : Persona
    {
        [Required(ErrorMessage = "La especialidad es obligatoria")]
        public string Especialidad { get; set; }
    }
}
