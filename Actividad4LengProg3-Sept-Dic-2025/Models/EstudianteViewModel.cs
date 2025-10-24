using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "Debe proporcionar su nombre completo")]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Phone]
        [MinLength(10)]
        public string Celular { get; set; }

        [Phone]
        [MinLength(10)]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Matricula { get; set; }

        [Required]
        public string Carrera { get; set; }

        [Required]
        public string Campus { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Tanda { get; set; }

        public bool EstaBecado { get; set; }

        [Range(0, 100)]
        public int? PorcentajeBeca { get; set; }
    }
}