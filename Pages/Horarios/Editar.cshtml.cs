using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Asistencias.Domain;

namespace Asistencias.Pages.Horarios
{
    public class EditarModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Domain.Grupo> Grupo { get; set; }

        [BindProperty]
        public Horario Editar { get; set; }

        public EditarModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int ID)
        {
            Grupo = dbContext.Grupos.ToList();
            var Dato = dbContext.Horarios.Find(ID);
            if (Dato != null)
            {
                Editar = new Horario()
                {
                    ID = Dato.ID,
                    Dia = Dato.Dia,
                    Entrada = Dato.Entrada,
                    Salida = Dato.Salida,
                    GrupoId = Dato.GrupoId
                };
            }

        }

        public void OnPostActualizar()
        {
            if (Editar != null)
            {
                var Registro = dbContext.Horarios.Find(Editar.ID);
                if (Registro != null)
                {
                    Registro.Dia = Editar.Dia;
                    Registro.Entrada = Editar.Entrada;
                    Registro.Salida = Editar.Salida;
                    Registro.GrupoId = Editar.GrupoId;
                    dbContext.SaveChanges();
                    Response.Redirect("/Horarios/Lista");
                }
            }
        }

        public IActionResult OnPostEliminar()
        {
            var Registro = dbContext.Horarios.Find(Editar.ID);

            if (Registro != null)
            {
                dbContext.Horarios.Remove(Registro);
                dbContext.SaveChanges();

                return RedirectToPage("/Horarios/Lista");
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
                return RedirectToPage("/Horarios/Editar", new { id });
            }
        }
    }
}
