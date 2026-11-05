using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Asistencias.Domain;

namespace Asistencias.Pages.Alumnos
{
    public class AñadirModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Domain.Grupo> Grupo { get; set; }

        public AñadirModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Grupo = dbContext.Grupos.ToList();
        }

        [BindProperty]
        public Alumno Añadir { get; set; }

        public void OnPost()
        {
            var AlModel = new Alumno
            {
                Nombre = Añadir.Nombre,
                ApellidoP = Añadir.ApellidoP,
                ApellidoM = Añadir.ApellidoM,
                GrupoId = Añadir.GrupoId
            };
            dbContext.Alumnos.Add(AlModel);
            dbContext.SaveChanges();
            Response.Redirect("/Alumnos/Lista");
        }
    }
}
