using Microsoft.EntityFrameworkCore;
using Asistencias.Domain;

namespace Asistencias.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Grupo> Grupos { get; set; }

        public DbSet<Horario> Horarios { get; set; }
        
        public DbSet<Entrada> Entradas { get; set; }

        public DbSet<Salida> Salidas { get; set; }
    }
}
