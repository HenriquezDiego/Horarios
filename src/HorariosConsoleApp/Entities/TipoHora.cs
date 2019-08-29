namespace HorariosConsoleApp.Entities
{
    public class TipoHora
    {
        public int TipoHoraId { get; set; }
        public string Nombre { get; set; }
        public bool EsNocturna { get; set; }
        public decimal PorcentajeExtra{ get; set; }
    }
}