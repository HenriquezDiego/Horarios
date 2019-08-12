namespace HorariosConsoleApp.Entities
{
    public class HoraDetalle
    {
        public int HoraDetalleId { get; set; }
        public int HorarioFraccionId { get; set; }
        public HorarioFraccion HorarioFraccion { get; set; }
        public int HoraId { get; set; }
        public Hora Hora { get; set; }
        public int TipoHoraId { get; set; }
        public TipoHora TipoHora { get; set; }
    }
}
