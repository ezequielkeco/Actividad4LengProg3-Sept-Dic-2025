using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "Proporcione el nombre completo")]
        [StringLength(100, ErrorMessage = "El nombre completo no puede exceder los 100 caracteres")]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres")]
        public string Direccion { get; set; }

        [Phone]
        [MinLength(10, ErrorMessage = "El número de celular no puede exceder los 10 caracteres")]
        public string Celular { get; set; }

        [Phone]
        [MinLength(10, ErrorMessage = "El número de teléfono no puede exceder los 10 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Indique la fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe indicar el género")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Debe indicar una matrícula")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La matrícula está comprendida entre 6 y  15 caracteres")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la carrera")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el campus")]
        public string Campus { get; set; }

        [Required(ErrorMessage = "Indique el correo institucional")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Seleccione una tanda")]
        public string Tanda { get; set; }

        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100")]
        public int? PorcentajeBeca { get; set; }
    }
}