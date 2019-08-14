using System;

namespace HorariosConsoleApp.Entities
{
    //Log!!!!
    public class CambioHorario
    {
        public int CambioHorarioId{ get; set; }
        public int? EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int? EquipoId { get; set; }
        public Equipo Equipo { get; set; }
        public int? HorarioId { get; set; }
        public Horario Horario { get; set; }

        public double HorasOrdinariasDiurnas { get; set; }
        public double TotalHorasOrdinariasDiurnas { get; set; }
        public double HorasOrdinariasNocturnas { get; set; }
        public double TotalHorasOrdinariasNocturnas { get; set; }
        public double HorasExtraDiurnas { get; set; }
        public double TotalHorasExtraDiurnas { get; set; }
        public double HorasExtraNocturnas { get; set; }
        public double TotalHorasExtraNocturnas { get; set; }
        public double TotalHorasOrinariasDiurnasDomingo { get; set; }
        public double HorasOrdinarioasNocturnasDomingo { get; set; }
        public double TotalHorasOrdinariasNocturnasDomingo { get; set; }
        public double HorasExtraDiurnasDomingo { get; set; }
        public double TotalHorasExtraDiurnasDomingo { get; set; }
        public double HorasExtraNocturnasDomingo { get; set; }
        public double TotalHorasExtraNocturnasDomingo { get; set; }
        public double TotalAsueto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
