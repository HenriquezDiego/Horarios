﻿namespace HorariosConsoleApp.Entities
{
    public class Empleado
    {
        public int  EmpleadoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal SalarioBase { get; set; }
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }
    }
}
