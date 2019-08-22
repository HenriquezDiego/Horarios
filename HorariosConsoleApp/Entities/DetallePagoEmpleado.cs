namespace HorariosConsoleApp.Entities
{
    public class DetallePagoEmpleado
    {
        public int DetallePagoEmpleadoId { get; set; }
        public int PagoEmpleadoId { get; set; }
        public decimal CantidadHoras { get; set; }
        public string TipoHora { get; set; }
        public bool EsNocturna { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
