using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        public static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>()
        {
            new EstudianteViewModel {
                NombreCompleto = "Ezequiel Santos",
                Direccion = "Calle 12 #31, Sto. Dgo. Oeste",
                Celular = "809-707-2389",
                Telefono = "809-524-5586",
                Genero = "Masculino",
                Matricula = "SD-2022-04397",
                Carrera = "Ingeniería de Software",
                Campus = "Santo Domingo Oeste",
                Correo = "SD-2022-04397@ufhec.edu.do",
                Tanda = "Nocturna"
            },

            new EstudianteViewModel {
                NombreCompleto = "Lorena Frías",
                Direccion = "Calle 20 #10, Sto. Dgo. D.N.",
                Celular = "809-254-5865",
                Telefono = "809-548-2520",
                Genero = "Femenino",
                Matricula = "SD-2022-21452",
                Carrera = "Enfermería",
                Campus = "Santo Domingo Oeste",
                Correo = "SD-2022-21452@ufhec.edu.do",
                Tanda = "Nocturna"
            }
        };

        private static List<CarreraViewModel> carreras = CarrerasController.carreras;

        private static List<RecintoViewModel> recintos = RecintosController.recintos;

        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.Carreras = carreras;
            ViewBag.Recintos = recintos;
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
      
        public IActionResult Editar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null) return NotFound();
            ViewBag.Carreras = CarrerasController.carreras;
            ViewBag.Recintos = RecintosController.recintos;
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