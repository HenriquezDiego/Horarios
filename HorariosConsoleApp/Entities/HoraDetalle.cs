using System;

namespace HorariosConsoleApp.Entities
{
    public class HoraDetalle
    {
        public int HoraDetalleId { get; set; }
        public int HorarioFragmentoId { get; set; }
        public HorarioFragmento HorarioFragmento { get; set; }
        public TimeSpan Hora { get; set; }
        public int TipoHoraId { get; set; }
        public TipoHora TipoHora { get; set; }
    }
}
