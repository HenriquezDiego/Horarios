namespace HorariosConsoleApp.Entities
{
    public class HoraDetalle
    {
        public int HoraDetalleId { get; set; }
        public int HorarioId { get; set; }
        public HorarioFraccion Horario { get; set; }
        public int HoraId { get; set; }
        public Hora Hora { get; set; }
        public int TipoHoraId { get; set; }
        public TipoHora TipoHora { get; set; }
    }
}
