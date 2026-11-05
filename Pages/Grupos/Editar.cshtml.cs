using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Asistencias.Domain;

namespace Asistencias.Pages.Grupos
{
    public class EditarModel : PageModel
    {
        private readonly AppDbContext dbContext;

        [BindProperty]
        public Grupo Editar { get; set; }

        public EditarModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int ID)
        {
            var Dato = dbContext.Grupos.Find(ID);
            if (Dato != null)
            {
                Editar = new Grupo()
                {
                    ID = Dato.ID,
                    GradoGrupo = Dato.GradoGrupo
                };
            }

        }

        public void OnPostActualizar()
        {
            if (Editar != null)
            {
                var Registro = dbContext.Grupos.Find(Editar.ID);
                if (Registro != null)
                {
                    Registro.GradoGrupo = Editar.GradoGrupo;
                    dbContext.SaveChanges();
                    Response.Redirect("/Grupos/Lista");
                }
            }
        }

        public IActionResult OnPostEliminar()
        {
            var Registro = dbContext.Grupos.Find(Editar.ID);

            if (Registro != null)
            {
                dbContext.Grupos.Remove(Registro);
                dbContext.SaveChanges();

                return RedirectToPage("/Grupos/Lista");
            }
            return Page();
        }

        public IActionResult OnPostBuscar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Ingrese un ID en el buscador";
                return Page();
            }
            else
            {
                return RedirectToPage("/Grupos/Editar", new { id });
            }
        }
    }
}
