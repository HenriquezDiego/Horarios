using System.Collections.Generic;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
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
                         Apellido = "Perez",
                         SalarioBase = 100
                     },
                     new Empleado()
                     {
                         EmpleadoId = 2,
                         Nombre = "Kevin",
                         Apellido = "Mitnick",
                         SalarioBase = 100
                     },
                     new Empleado()
                     {
                         EmpleadoId = 3,
                         Nombre = "Jose",
                         Apellido = "Quezada",
                         SalarioBase = 700
                     },
                     new Empleado()
                     {
                         EmpleadoId = 4,
                         Nombre = "Juan",
                         Apellido = "Rulfo",
                         SalarioBase = 700
                     },
                     new Empleado()
                     {
                         EmpleadoId = 5,
                         Nombre = "Francisco",
                         Apellido = "García",
                         SalarioBase = 100
                     },
                     new Empleado()
                     {
                         EmpleadoId = 6,
                         Nombre = "Tito",
                         Apellido = "Hernandez",
                         SalarioBase = 700
                     },
                     new Empleado()
                     {
                         EmpleadoId = 7,
                         Nombre = "Pedro",
                         Apellido = "Rendon",
                         SalarioBase = 700
                     },
                     new Empleado()
                     {
                         EmpleadoId = 8,
                         Nombre = "Elmer",
                         Apellido = "Gonzales",
                         SalarioBase = 700
                     }
                 }
                );
        }
    }
}
