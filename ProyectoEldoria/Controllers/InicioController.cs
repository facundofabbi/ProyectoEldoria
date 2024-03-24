using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoEldoria.Datos;
using ProyectoEldoria.Models;
using System.Diagnostics;
using static ProyectoEldoria.Models.Aventurero;

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
            var aventureros = await _contexto.Aventurero.ToListAsync();
            return View(aventureros);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            CargarOpcionesEnums();

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
            CargarOpcionesEnums();
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
            CargarOpcionesEnums();
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
            CargarOpcionesEnums();
            return View();
        }

        private void CargarOpcionesEnums()
        {
            var clases = Enum.GetValues(typeof(ClaseEnum)).Cast<ClaseEnum>().ToList();
            var razas = Enum.GetValues(typeof(RazaEnum)).Cast<RazaEnum>().ToList();
            var elementos = Enum.GetValues(typeof(ElementoEnum)).Cast<ElementoEnum>().ToList();

            ViewBag.Clases = new SelectList(clases);
            ViewBag.Razas = new SelectList(razas);
            ViewBag.Elementos = new SelectList(elementos);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
