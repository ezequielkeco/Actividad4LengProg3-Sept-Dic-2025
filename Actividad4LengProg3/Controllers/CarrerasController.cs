using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Actividad4LengProg3.Controllers
{
    public class CarrerasController : Controller
    {
        private static List<CarreraViewModel> carreras = new List<CarreraViewModel>();

        public IActionResult Index()
        {
            return View(carreras);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(CarreraViewModel model)
        {
            if (ModelState.IsValid)
            {
                carreras.Add(model);
                TempData["SuccessMessage"] = "Carrera registrada correctamente.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Editar(string codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera == null) return NotFound();
            return View(carrera);
        }

        [HttpPost]
        public IActionResult Editar(CarreraViewModel model)
        {
            if (ModelState.IsValid)
            {
                var carrera = carreras.FirstOrDefault(c => c.Codigo == model.Codigo);
                if (carrera != null)
                {
                    carrera.Nombre = model.Nombre;
                    carrera.CantidadCreditos = model.CantidadCreditos;
                    carrera.CantidadMaterias = model.CantidadMaterias;
                    TempData["SuccessMessage"] = "Carrera actualizada correctamente.";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Eliminar(string codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera != null)
            {
                carreras.Remove(carrera);
                TempData["SuccessMessage"] = "Carrera eliminada correctamente.";
            }
            return RedirectToAction("Index");
        }
    }
}
