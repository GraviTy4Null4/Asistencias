using System.ComponentModel.DataAnnotations;

namespace Asistencias.Domain
{
    public class Horario
    {
        [Key]
        public int ID { get; set; }

        public string Dia { get; set; }

        public DateTime Entrada { get; set; }

        public DateTime Salida { get; set; }

        public int GrupoId { get; set; }

        public Grupo Grupo { get; set; }
    }
}
