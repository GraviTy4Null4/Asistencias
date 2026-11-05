using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Microsoft.EntityFrameworkCore;

namespace Asistencias.Pages.Alumnos
{
    public class ListaModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Domain.Alumno> Alumno { get; set; }

        public ListaModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Alumno = dbContext.Alumnos.ToList();
        }
    }
}
