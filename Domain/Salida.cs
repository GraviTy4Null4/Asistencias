using System.ComponentModel.DataAnnotations;

namespace Asistencias.Domain
{
    public class Salida
    {
        [Key]
        public int ID { get; set; }

        public DateTime Hora { get; set; }

        public int AlumnoId { get; set; }

        public Alumno Alumno { get; set; }
    }
}
