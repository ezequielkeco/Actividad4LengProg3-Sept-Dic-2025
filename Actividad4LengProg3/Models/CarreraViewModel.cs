using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class CarreraViewModel
    {
        [Required(ErrorMessage = "Proporcione el código de la carrera.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Proporcione el nombre de la carrera.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Indique la cantidad de créditos.")]
        public int CantidadCreditos { get; set; }

        [Required(ErrorMessage = "Indique la cantidad de materias")]
        public int CantidadMaterias {  get; set; }
    }
}
