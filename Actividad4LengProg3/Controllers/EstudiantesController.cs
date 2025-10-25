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

        public IActionResult Index()
        {
            return View(estudiantes);
        }

        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                estudiantes.Add(model);
                TempData["SuccessMessage"] = "Estudiante registrado de forma exitosa.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListaDeEstudiantes()
        {
            return View(estudiantes);
        }
      
        public IActionResult Editar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == model.Matricula);
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
                    TempData["SuccessMessage"] = "Información del estudiante editada satisfactoriamente.";
                }
                return RedirectToAction("ListaDeEstudiantes");
            }
            return View(model);
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