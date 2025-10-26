using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class RecintoViewModel
    {
        [Required(ErrorMessage = "Debe proporcionar el código del recinto.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el nombre del recinto.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe proporcionar la dirección del recinto.")]
        [StringLength(100, ErrorMessage = "La dirección no puede exceder los 100 caracteres.")]
        public string Direccion { get; set; }
    }
}
