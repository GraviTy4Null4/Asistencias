using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;

namespace Asistencias.Pages.Horarios
{
    public class ListaModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Domain.Horario> Horario { get; set; }

        public ListaModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet()
        {
            Horario = dbContext.Horarios.ToList();
        }
    }
}
