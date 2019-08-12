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
                         Nombre = "Juan",
                         Apellido = "Perez"
                     },
                     new Empleado()
                     {
                         Nombre = "Kevin",
                         Apellido = "Mitnick"
                     },
                     new Empleado()
                     {
                         Nombre = "Jose",
                         Apellido = "Quezada"
                     },
                     new Empleado()
                     {
                         Nombre = "Juan",
                         Apellido = "Rulfo"
                     },
                 }
                );
        }
    }
}
