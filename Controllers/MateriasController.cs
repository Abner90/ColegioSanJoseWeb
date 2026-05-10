using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColegioSanJoseWeb.Data;
using ColegioSanJoseWeb.Models;

namespace ColegioSanJoseWeb.Controllers
{
    public class MateriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materias.ToListAsync());
        }

        // FORMULARIO CREAR
        public IActionResult Create()
        {
            return View();
        }

        // GUARDAR
        [HttpPost]
        public async Task<IActionResult> Create(Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        // FORMULARIO EDITAR
        public async Task<IActionResult> Edit(int id)
        {
            var materia = await _context.Materias.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GUARDAR EDICIÓN
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Materia materia)
        {
            if (id != materia.IdMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(materia);
        }

        // ELIMINAR
        public async Task<IActionResult> Delete(int id)
        {
            var materia = await _context.Materias.FindAsync(id);

            if (materia != null)
            {
                _context.Materias.Remove(materia);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}