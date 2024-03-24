using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoEldoria.Datos;
using ProyectoEldoria.Models;
using System.Diagnostics;

namespace ProyectoEldoria.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public InicioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Aventurero.ToListAsync());
        }


        [HttpGet]
        public IActionResult Crear()
        {
            List<Mentor> Mentores = _contexto.Mentor.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Aventurero aventurero)
        {
            if (ModelState.IsValid)
            {
                _contexto.Aventurero.Add(aventurero);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }
            var aventurero = _contexto.Aventurero.Find(codigo);
            if(aventurero == null)
            {
                return NotFound();
            }
            return View(aventurero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Aventurero aventurero)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(aventurero);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
