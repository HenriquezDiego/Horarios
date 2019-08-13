using System.Collections.Generic;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasData(
                 new List<Empleado>()
                 {
                     new Empleado()
                     {
                         EmpleadoId = 1,
                         Nombre = "Juan",
                         Apellido = "Perez"
                     },
                     new Empleado()
                     {
                         EmpleadoId = 2,
                         Nombre = "Kevin",
                         Apellido = "Mitnick"
                     },
                     new Empleado()
                     {
                         EmpleadoId = 3,
                         Nombre = "Jose",
                         Apellido = "Quezada"
                     },
                     new Empleado()
                     {
                         EmpleadoId = 4,
                         Nombre = "Juan",
                         Apellido = "Rulfo"
                     },
                 }
                );
        }
    }
}
