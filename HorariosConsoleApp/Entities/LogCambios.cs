using System;

namespace HorariosConsoleApp.Entities
{
    public class LogCambios
    {
        public int LogCambiosId { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }
        public int? HorarioId { get; set; }
        public Horario Horario { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

}