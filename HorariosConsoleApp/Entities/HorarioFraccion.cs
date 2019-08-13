using System;

namespace HorariosConsoleApp.Entities
{
    public class HorarioFraccion
    {
        public int HorarioFraccionId { get; set; }
        public int DiaId { get; set; }
        public Dia Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin{ get; set; }

    }
}