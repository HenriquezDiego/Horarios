using System.Collections.Generic;

namespace HorariosConsoleApp.Entities
{
    public class Horario
    {
        public int HorarioId { get; set; }
        public string Descripcion { get; set; }
        public List<HorarioFraccion> HorarioFraccions { get; set; }
    }
}