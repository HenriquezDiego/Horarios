using System;

namespace HorariosConsoleApp.Entities
{
    public class HorarioFragmentoDetalle
    {
        public int HorarioFragmentoDetalleId { get; set; }
        public int HorarioFragmentoId { get; set; }
        public HorarioFragmento HorarioFragmento { get; set; }
        public TimeSpan Hora { get; set; }
        public int TipoHoraId { get; set; }
        public TipoHora TipoHora { get; set; }
    }
}
