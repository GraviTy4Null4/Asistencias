using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Asistencias.Domain;

namespace Asistencias.Pages.Salidas
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
        public Salida Añadir { get; set; }

        public void OnPostEnviar()
        {
            var AlModel = new Salida
            {
                AlumnoId = Añadir.AlumnoId,
                Hora = Añadir.Hora
            };
            dbContext.Salidas.Add(AlModel);
            dbContext.SaveChanges();
        }
    }
}
