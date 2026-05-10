using Microsoft.EntityFrameworkCore;
using ColegioSanJoseWeb.Models;

namespace ColegioSanJoseWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tablas
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clave primaria de Expediente
            modelBuilder.Entity<Expediente>()
                .HasKey(e => e.IdExpediente);

            // Relación: Alumno 1 - N Expedientes
            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Alumno)
                .WithMany(a => a.Expedientes)
                .HasForeignKey(e => e.IdAlumno)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación: Materia 1 - N Expedientes
            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Materia)
                .WithMany() // (si luego agregas colección en Materia se puede ajustar)
                .HasForeignKey(e => e.IdMateria)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}