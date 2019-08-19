namespace HorariosConsoleApp.Entities
{
    public class ConsultaDetalleHoras
    {
        public int NumeroHoras { get; set; }
        public int TipoHoraId { get; set; }
        public string TipoHora { get; set; }
        public decimal PorcentajeHora { get; set; }
        public string Horario { get; set; }
        public int DiaId { get; set; }
        public string Dia { get; set; }
    }
}
