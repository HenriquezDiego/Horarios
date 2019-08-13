namespace HorariosConsoleApp.Entities
{
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string Descripcion { get; set; }
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }
    }
}