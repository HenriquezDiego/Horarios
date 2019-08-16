using System;
using System.Collections.Generic;

namespace HorariosConsoleApp.Entities
{
    //Log!!!!
    public class PagoEmpleado
    {
        public int PagoEmpleadoId{ get; set; }
        public int? EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public decimal SalarioHora { get; set; }
        public string Equipo { get; set; }
        public string Horario { get; set; }
        public string Dia { get; set; }
        public DateTime FechaPago { get; set; }
        public bool EsAsueto { get; set; }
        public double TotalAsueto { get; set; }
        public List<DetallePagoEmpleado> DetallePago { get; set; }

    }
}
