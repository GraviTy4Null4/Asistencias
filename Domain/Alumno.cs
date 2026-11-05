using System.ComponentModel.DataAnnotations;

namespace Asistencias.Domain
{
    public class Alumno
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public int GrupoId { get; set; }

        public List<Entrada> Entradas { get; set; }

        public List<Salida> Salidas { get; set; }
    }
}
