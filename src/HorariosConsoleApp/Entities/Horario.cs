using System.Collections.Generic;

namespace HorariosConsoleApp.Entities
{
    public class Horario
    {
        public int HorarioId { get; set; }
        public string Alias { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public List<HorarioFragmento> HorarioFragmentos { get; set; }
    }
}