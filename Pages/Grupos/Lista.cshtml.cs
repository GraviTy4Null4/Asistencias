using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asistencias.Data;

namespace Asistencias.Pages.Grupos
{
    public class ListaModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public IList<Domain.Grupo> Grupo { get; set; }

        public ListaModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            Grupo = await dbContext.Grupos
                .Include(g => g.Alumnos)
                .Include(g => g.Horarios)
                .ToListAsync();
        }
    }
}
