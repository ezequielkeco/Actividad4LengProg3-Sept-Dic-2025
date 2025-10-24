using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                estudiantes.Add(model);

                TempData["SuccessMessage"] = "Estudiante agregado de forma exitosa.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", model);
        }

        [HttpGet]
        public IActionResult ListaDeEstudiantes()
        {
            return View(estudiantes);
        }
        [HttpGet]
        public IActionResult Editar(string id)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula.Equals(id, StringComparison.InvariantCultureIgnoreCase));

            if (estudiantes != null)
            {
                return View(estudiante);
            }

            return RedirectToAction("ListaDeEstudiantes", estudiante);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {

                var estudiante = estudiantes.FirstOrDefault(e => e.Matricula.Equals(model.Matricula, StringComparison.InvariantCultureIgnoreCase));

                if (estudiantes != null)
                {
                    estudiante.NombreCompleto = model.NombreCompleto;
                    estudiante.Carrera = model.Carrera;
                    estudiante.Correo = model.Correo;
                    estudiante.Direccion = model.Direccion;
                    estudiante.Campus = model.Campus;
                    estudiante.FechaNacimiento = model.FechaNacimiento;
                    estudiante.Celular = model.Celular;
                    estudiante.Telefono = model.Telefono;
                    estudiante.Genero = model.Genero;
                    estudiante.Tanda = model.Tanda;

                    TempData["SuccessMessage"] = "Información del estudiante editada de forma exitosa.";
                    return View(estudiante);
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", model);
        }
        [HttpPost]
        public IActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
                TempData["SuccessMessage"] = "Estudiante eliminado correctamente.";
            }

            return RedirectToAction("ListaDeEstudiantes");
        }
    }
}