using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Asistencias.Domain;

namespace Asistencias.Pages.Horarios
{
    public class AñadirModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Domain.Grupo> Grupo { get; set; }

        public AñadirModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Horario Añadir { get; set; }

        public void OnGet()
        {
            Grupo = dbContext.Grupos.ToList();
        }

        public void OnPost()
        {
            var AlModel = new Horario
            {
                Dia = Añadir.Dia,
                Entrada = Añadir.Entrada,
                Salida = Añadir.Salida,
                GrupoId = Añadir.GrupoId
            };
            dbContext.Horarios.Add(AlModel);
            dbContext.SaveChanges();
            Response.Redirect("/Alumnos/Lista");
        }
    }
}
