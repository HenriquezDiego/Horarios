using System.Collections.Generic;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>

    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.HasData(new List<Equipo>() 
            {
                new Equipo()
                {
                    EquipoId = 1,
                    Nombre = "Bravo",
                },
                new Equipo()
                {
                    EquipoId = 2,
                    Nombre = "Cobra",
                },
                new Equipo()
                {
                    EquipoId = 3,
                    Nombre = "Zebra",
                }

            });
        }
    }
}
