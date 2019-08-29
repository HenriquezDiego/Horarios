using System;

namespace HorariosConsoleApp.Entities
{
    public class HorarioFragmento
    {
        public int HorarioFragmentoId { get; set; }
        public int DiaId { get; set; }
        public Dia Dia { get; set; }
        public bool EsNocturno { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin{ get; set; }

    }
}