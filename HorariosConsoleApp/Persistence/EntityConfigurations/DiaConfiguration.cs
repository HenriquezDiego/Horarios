using System.Collections.Generic;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class DiaConfiguration : IEntityTypeConfiguration<Dia>
    {
        public void Configure(EntityTypeBuilder<Dia> builder)
        {
            builder.HasData(new List<Dia>()
            {
                new Dia()
                {
                    DiaId = 1,
                    Nombre = "Lunes",
                    Abreviatura = "LN",
                },
                new Dia()
                {
                    DiaId = 1,
                    Nombre = "Martes",
                    Abreviatura = "LN",
                },
                new Dia()
                {
                    DiaId = 1,
                    Nombre = "Miércoles",
                    Abreviatura = "LN",
                },
                new Dia()
                {
                    DiaId = 1,
                    Nombre = "Jueves",
                    Abreviatura = "LN",
                },
                new Dia()
                {
                    DiaId = 1,
                    Nombre = "Viernes",
                    Abreviatura = "LN",
                },
                new Dia()
                {
                    DiaId = 1,
                    Nombre = "Sábado",
                    Abreviatura = "LN",
                },
                new Dia()
                {
                    DiaId = 1,
                    Nombre = "Domingo",
                    Abreviatura = "LN",
                },

            });
        }
    }
}
