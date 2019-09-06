using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HorariosConsoleApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<HorarioFragmentoDetalle> HorarioFragmentoDetalle { get; set; }
        public DbSet<HorarioFragmento> HorariosFragmentos { get; set; }
        public DbSet<TipoHora> TipoHoras { get; set; }
        public DbSet<Dia> Dias { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<PagoEmpleado> PagoEmpleados { get; set; }
        public DbSet<Asueto> Asuetos { get; set; }
        public DbQuery<DetalleHoras> HoraDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server=localhost;Database=HorarioDbV2.0.1;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfiguration(new TipoHoraConfig())
                        .ApplyConfiguration(new HorarioConfig())
                        .ApplyConfiguration(new DiaConfig())
                        .ApplyConfiguration(new AsuetoConfig());

            modelBuilder.Query<DetalleHoras>().ToView("DetalleHoras");
            
        }
    }
}
