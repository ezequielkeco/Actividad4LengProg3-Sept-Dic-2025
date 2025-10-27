using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Actividad4LengProg3.Controllers
{
    public class RecintosController : Controller
    {
        public static List<RecintoViewModel> recintos = new List<RecintoViewModel>()
        {
        new RecintoViewModel { Codigo = "R001", Nombre = "Santo Domingo Oeste", Direccion = "Av.Isabel Aguiar #100, Herrera, Santo Domingo Oeste, Rep. Dom." },
        new RecintoViewModel { Codigo = "R002", Nombre = "Metropolitano", Direccion = "Av. Máximo Gómez esq. César Nicolás Penson, La Esperilla, Santo Domingo, D.N., Rep. Dom." },
        new RecintoViewModel { Codigo = "R003", Nombre = "Baní", Direccion = "Km. 1 Carretera Sánchez, Escondido, Bani, Rep. Dom." },
        };
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
                    recinto.Direccion = model.Direccion;
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