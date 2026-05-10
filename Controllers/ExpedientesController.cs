using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ColegioSanJoseWeb.Data;
using ColegioSanJoseWeb.Models;

namespace ColegioSanJoseWeb.Controllers
{
    public class ExpedientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpedientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            var expedientes = _context.Expedientes
                .Include(e => e.Alumno)
                .Include(e => e.Materia);

            return View(await expedientes.ToListAsync());
        }

        // FORMULARIO CREATE
        public IActionResult Create()
        {
            ViewBag.Alumnos = new SelectList(_context.Alumnos, "IdAlumno", "Nombre");
            ViewBag.Materias = new SelectList(_context.Materias, "IdMateria", "NombreMateria");

            return View();
        }

        // GUARDAR CREATE
        [HttpPost]
        public async Task<IActionResult> Create(Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Alumnos = new SelectList(_context.Alumnos, "IdAlumno", "Nombre", expediente.IdAlumno);
            ViewBag.Materias = new SelectList(_context.Materias, "IdMateria", "NombreMateria", expediente.IdMateria);

            return View(expediente);
        }

        // FORMULARIO EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);

            if (expediente == null)
            {
                return NotFound();
            }

            ViewBag.Alumnos = new SelectList(_context.Alumnos, "IdAlumno", "Nombre", expediente.IdAlumno);
            ViewBag.Materias = new SelectList(_context.Materias, "IdMateria", "NombreMateria", expediente.IdMateria);

            return View(expediente);
        }

        // GUARDAR EDIT
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Expediente expediente)
        {
            if (id != expediente.IdExpediente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(expediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(expediente);
        }

        // ELIMINAR
        public async Task<IActionResult> Delete(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);

            if (expediente != null)
            {
                _context.Expedientes.Remove(expediente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}