using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Asistencias.Domain;

namespace Asistencias.Pages.Grupos
{
    public class AñadirModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public AñadirModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Grupo Añadir { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var GrModel = new Grupo
            {
                GradoGrupo = Añadir.GradoGrupo
            };
            dbContext.Grupos.Add(GrModel);
            dbContext.SaveChanges(); 
            Response.Redirect("/Grupos/Lista");
        }
    }
}
