using System;

namespace HorariosConsoleApp.Entities
{
    public class PagoEmpleado
    {
        public int PagoEmpleadoId{ get; set; }
        public int? EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int? EquipoId { get; set; }
        public Equipo Equipo { get; set; }
        public int? HorarioId { get; set; }
        public Horario Horario { get; set; }
        public int DiaId { get; set; }
        public Dia  Dia { get; set; }
        public DateTime FechaPago { get; set; }
        public bool EsAsueto { get; set; }
    }
}

