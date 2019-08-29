using System.Collections.Generic;

namespace HorariosConsoleApp.Entities
{
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public int? HorarioId { get; set; }
        public Horario Horario { get; set; }
        public List<Empleado> Empleados { get; set; }
    }
}