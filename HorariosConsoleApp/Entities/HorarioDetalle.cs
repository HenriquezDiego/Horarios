namespace HorariosConsoleApp.Entities
{
    public class HorarioDetalle
    {
        public int HorarioDetalleId { get; set; }
        public int? HorarioId { get; set; }
        public Horario Horario { get; set; }
        public int DiaId { get; set; }
        public Dia Dia { get; set; } 
        public int HoraId { get; set; }
        public Hora Hora { get; set; } 
        public decimal Cantidad { get; set; }
    }
}
