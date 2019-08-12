namespace HorariosConsoleApp.Entities
{
    public class Horario
    {
        public int HorarioId { get; set; }
        public string Descripcion { get; set; }
        public int DiaId { get; set; }
        public Dia Dia { get; set; }
        public int? HoraInicioId { get; set; }
        public Hora HoraInicio { get; set; }
        public int? HoraFinId { get; set; }
        public Hora HoraFin{ get; set; }
        
    }
}