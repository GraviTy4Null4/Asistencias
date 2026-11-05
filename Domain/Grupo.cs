using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Asistencias.Domain
{
    public class Grupo
    {
        [Key]
        public int ID { get; set; }

        public string GradoGrupo { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public List<Horario> Horarios { get; set; }
    }
}
