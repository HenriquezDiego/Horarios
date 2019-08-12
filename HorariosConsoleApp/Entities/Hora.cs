using System;

namespace HorariosConsoleApp.Entities
{
    public class Hora
    {
        public int HoraId { get; set; }
        public TimeSpan Horaspan { get; set; }
        public int TipoHoraId { get; set; }
        public TipoHora TipoHora { get; set; }
    }
}