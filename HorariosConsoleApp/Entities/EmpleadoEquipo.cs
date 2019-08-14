namespace HorariosConsoleApp.Entities
{
    public class EmpleadoEquipo
    {
        public int EmpleadoEquipoId { get; set; }
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
