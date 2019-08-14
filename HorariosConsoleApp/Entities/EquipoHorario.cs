namespace HorariosConsoleApp.Entities
{
    public class EquipoHorario
    {
        public int EquipoHorarioId { get; set; }
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }
        public int? HorarioId { get; set; }
        public Horario Horario { get; set; }
    }
}
