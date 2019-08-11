namespace HorariosConsoleApp.Entities
{
    public class HorarioDetalle
    {
        public int HorarioDetalleId { get; set; }
        public int DiaId { get; set; }
        public Dia Dia { get; set; } 
        public int HoraInicioId { get; set; }
        public Hora HoraInicio { get; set; }
        public int HoraFinId { get; set; }
        public Hora HoraFin{ get; set; }
    }
}
