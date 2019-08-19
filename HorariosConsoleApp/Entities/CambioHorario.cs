using System;

namespace HorariosConsoleApp.Entities
{
    //Log!!!!
    public class CambioHorario
    {
        public int CambioHorarioId{ get; set; }
        public int? EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public string Equipo { get; set; }
        public string Horario { get; set; }
        public double TotalAsueto { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
