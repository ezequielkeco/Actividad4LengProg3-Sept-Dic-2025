using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class CarreraViewModel
    {
        [Required(ErrorMessage = "Debe proporcionar el código de la carrera.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el nombre de la carrera.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe indicar la cantidad de créditos.")]
        public int CantidadCreditos { get; set; }
    }
}
