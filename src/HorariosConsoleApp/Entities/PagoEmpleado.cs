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
        public decimal SalarioBase { get; set; }
        public string Equipo { get; set; }
        public string Horario { get; set; }
        public DateTime Fecha { get; set; }
        public int DiasLaborados { get; set; }
        public int DiasCompensatorios{ get; set; }
        public int PlanillaId { get; set; }
        public List<DetallePagoEmpleado> DetallePagoEmpleados { get; set; }

    }
}
