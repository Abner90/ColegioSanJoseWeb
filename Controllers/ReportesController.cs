using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColegioSanJoseWeb.Data;
using ColegioSanJoseWeb.Models;

namespace ColegioSanJoseWeb.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Vista de tabla de promedios
        public async Task<IActionResult> Promedios()
        {
            var promedios = await _context.Expedientes
                .Include(e => e.Alumno)
                .GroupBy(e => new
                {
                    e.IdAlumno,
                    e.Alumno.Nombre,
                    e.Alumno.Apellido
                })
                .Select(g => new PromedioAlumno
                {
                    NombreCompleto = g.Key.Nombre + " " + g.Key.Apellido,
                    Promedio = g.Average(x => x.NotaFinal)
                })
                .ToListAsync();

            return View(promedios);
        }

        // Vista de gráfico
        public async Task<IActionResult> Grafico()
        {
            var promedios = await _context.Expedientes
                .Include(e => e.Alumno)
                .GroupBy(e => new
                {
                    e.IdAlumno,
                    e.Alumno.Nombre,
                    e.Alumno.Apellido
                })
                .Select(g => new PromedioAlumno
                {
                    NombreCompleto = g.Key.Nombre + " " + g.Key.Apellido,
                    Promedio = g.Average(x => x.NotaFinal)
                })
                .ToListAsync();

            return View(promedios);
        }
    }
}