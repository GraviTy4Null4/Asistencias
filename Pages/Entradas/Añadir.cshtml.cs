using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Asistencias.Domain;

namespace Asistencias.Pages.Entradas
{
    public class AñadirModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Alumno> Alumno { get; set; }

        public AñadirModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Alumno = dbContext.Alumnos.ToList();
        }

        [BindProperty]
        public Entrada Añadir { get; set; }

        public void OnPostEnviar()
        {
            var AlModel = new Entrada
            {
                AlumnoId = Añadir.AlumnoId,
                Hora = Añadir.Hora
            };
            dbContext.Entradas.Add(AlModel);
            dbContext.SaveChanges();
        }
    }
}
