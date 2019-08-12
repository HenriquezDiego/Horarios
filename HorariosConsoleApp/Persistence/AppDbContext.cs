using System.Linq;
using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HorariosConsoleApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EmpleadoEquipo> EmpleadosEquipos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<HoraDetalle> HoraDetalles { get; set; }
        public DbSet<HorarioFraccion> HorarioFraccion { get; set; }
        public DbSet<Hora> Horas { get; set; }
        public DbSet<TipoHora> TipoHoras { get; set; }
        public DbSet<Dia> Dias { get; set; }
        public DbSet<EquipoHorario> EquipoHorarios { get; set; }
        public DbSet<Horario> Horarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server=localhost;Database=HorarioDb;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfiguration(new EmpleadoConfiguration())
                        .ApplyConfiguration(new EquipoConfiguration())
                        .ApplyConfiguration(new HoraConfiguration())
                        .ApplyConfiguration(new TipoHoraConfiguration())
                        .ApplyConfiguration(new DiaConfiguration());
        }
    }
}
