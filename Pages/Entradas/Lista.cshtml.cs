using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;

namespace Asistencias.Pages.Entradas
{
    public class ListaModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Domain.Entrada> Entradas { get; set; }

        public ListaModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet()
        {
            Entradas = dbContext.Entradas.ToList();
        }
    }
}
