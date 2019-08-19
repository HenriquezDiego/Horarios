namespace HorariosConsoleApp.Entities
{
    public class ConsultaDetalleHoras
    {
        public decimal NumeroHoras { get; set; }
        public int TipoHoraId { get; set; }
        public string TipoHora { get; set; }
        public string Horario { get; set; }
        public int DiaId { get; set; }
        public string Dia { get; set; }
    }
}
