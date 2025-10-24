using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Actividad4LengProg3.Controllers
{
    public class RecintosController : Controller
    {
        private static List<RecintoViewModel> recintos = new List<RecintoViewModel>();

        public IActionResult Index()
        {
            return View(recintos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(RecintoViewModel model)
        {
            if (ModelState.IsValid)
            {
                recintos.Add(model);
                TempData["SuccessMessage"] = "Recinto registrado correctamente.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Editar(string codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto == null) return NotFound();
            return View(recinto);
        }

        [HttpPost]
        public IActionResult Editar(RecintoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recinto = recintos.FirstOrDefault(r => r.Codigo == model.Codigo);
                if (recinto != null)
                {
                    recinto.Nombre = model.Nombre;
                    TempData["SuccessMessage"] = "Recinto actualizado correctamente.";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Eliminar(string codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto != null)
            {
                recintos.Remove(recinto);
                TempData["SuccessMessage"] = "Recinto eliminado correctamente.";
            }
            return RedirectToAction("Index");
        }
    }
}
