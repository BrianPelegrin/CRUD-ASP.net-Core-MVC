using CursoMaster_Proyecto_1.Datos;
using CursoMaster_Proyecto_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CursoMaster_Proyecto_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public HomeController(ApplicationDBContext context)
        {
            _contexto = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Usuarios.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuarios Model)
        {
            if (ModelState.IsValid) 
            {
                _contexto.Usuarios.Add(Model);

                await _contexto.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            else
            {
              return View();  
            }
            
        }

        [HttpGet]
        public IActionResult Editar(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var modelo = _contexto.Usuarios.Find(id);
            if (modelo == null) 
            {
                return NotFound();
            }
            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuarios usuarios) 
        {
            if (ModelState.IsValid) 
            {
                _contexto.Usuarios.Update(usuarios);

                await _contexto.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); 

            }
            return View();
        }

        [HttpGet]
        public IActionResult Eliminar(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var modelo = _contexto.Usuarios.Find(id);
            if(modelo == null) 
            {
                return NotFound();
            }

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(string id) 
        {
            if(id == null) 
            {
                return NotFound();
            }
             var Modelo = await _contexto.Usuarios.FindAsync(Convert.ToInt32(id));
            if(Modelo == null) 
            {
                return NotFound();
            }
              _contexto.Usuarios.Remove(Modelo);
           await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Detalles(int? id) 
        {
            if (id == null) 
            {
                return  NotFound(); ;
            }
            var modelo = _contexto.Usuarios.Find(id);
            if (modelo==null)
            {
                return NotFound();
            }
            return View(modelo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}