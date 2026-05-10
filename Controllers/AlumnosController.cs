using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColegioSanJoseWeb.Data;
using ColegioSanJoseWeb.Models;

namespace ColegioSanJoseWeb.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlumnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // LISTAR (INDEX)
        // =========================
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Alumnos.ToListAsync();
            return View(lista);
        }

        // =========================
        // CREAR (GET)
        // =========================
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // CREAR (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumnos.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(alumno);
        }

        // =========================
        // EDITAR (GET)
        // =========================
        public async Task<IActionResult> Edit(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);

            if (alumno == null)
                return NotFound();

            return View(alumno);
        }

        // =========================
        // EDITAR (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumnos.Update(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(alumno);
        }

        // =========================
        // ELIMINAR
        // =========================
        public async Task<IActionResult> Delete(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);

            if (alumno == null)
                return NotFound();

            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}