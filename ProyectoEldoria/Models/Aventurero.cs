using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEldoria.Models
{
    public class Aventurero : Persona
    {
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateOnly FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El correo magico es obligatorio")]
        public String Correo { get; set; }
        [Required(ErrorMessage = "La clase es obligatoria")]
        public String Clase { get; set; }
        [Required(ErrorMessage = "La raza es obligatoria")]
        public String Raza { get; set; }
        [Required(ErrorMessage = "El elemento es obligatorio")]
        public String Elemento { get; set; }
        [Required(ErrorMessage = "El compañero de viaje es obligatorio")]
        public String Companiero { get; set; }
        [Required(ErrorMessage = "Las habilidades son obligatorias")]
        public List<String> Habilidades { get; set; }

        public String Mentor { get; set; }

        // Enumeración para la propiedad Clase
        public enum ClaseEnum
        {
            Guerrero,
            Mago,
            Arquero
        }

        // Enumeración para la propiedad Raza
        public enum RazaEnum
        {
            Humano,
            Elfo,
            Enano,
            Orco
        }

        // Enumeración para la propiedad Elemento
        public enum ElementoEnum
        {
            Fuego,
            Agua,
            Aire,
            Tierra,
            Luz,
            Oscuridad
        }


    }
}
