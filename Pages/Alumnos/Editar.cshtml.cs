using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Asistencias.Data;
using Asistencias.Domain;

namespace Asistencias.Pages.Alumnos
{
    public class EditarModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Domain.Grupo> Grupo { get; set; }

        [BindProperty]
        public Alumno Editar { get; set; }

        public EditarModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int ID)
        {
            Grupo = dbContext.Grupos.ToList();
            var Dato = dbContext.Alumnos.Find(ID);
            if (Dato != null)
            {
                Editar = new Alumno()
                {
                    ID = Dato.ID,
                    Nombre = Dato.Nombre,
                    ApellidoP = Dato.ApellidoP,
                    ApellidoM = Dato.ApellidoM,
                    GrupoId = Dato.GrupoId
                };
            }

        }

        public void OnPostActualizar()
        {
            if (Editar != null)
            {
                var Registro = dbContext.Alumnos.Find(Editar.ID);
                if (Registro != null)
                {
                    Registro.Nombre = Editar.Nombre;
                    Registro.ApellidoP = Editar.ApellidoP;
                    Registro.ApellidoM = Editar.ApellidoM;
                    Registro.GrupoId = Editar.GrupoId;
                    dbContext.SaveChanges();
                    Response.Redirect("/Alumnos/Lista");
                }
            }
        }

        public IActionResult OnPostEliminar()
        {
            var Registro = dbContext.Alumnos.Find(Editar.ID);

            if (Registro != null)
            {
                dbContext.Alumnos.Remove(Registro);
                dbContext.SaveChanges();

                return RedirectToPage("/Alumnos/Lista");
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
                return RedirectToPage("/Alumnos/Editar", new { id });
            }
        }
    }
}
