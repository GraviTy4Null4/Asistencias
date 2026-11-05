using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;

namespace Asistencias.Pages.Salidas
{
    public class ListaModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Domain.Salida> Salidas { get; set; }

        public ListaModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet()
        {
            Salidas = dbContext.Salidas.ToList();
        }
    }
}
