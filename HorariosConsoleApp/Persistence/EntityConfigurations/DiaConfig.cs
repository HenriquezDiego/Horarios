using System.Collections.Generic;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class DiaConfig : IEntityTypeConfiguration<Dia>
    {
        public void Configure(EntityTypeBuilder<Dia> builder)
        {
            builder.HasData(new List<Dia>()
            {
                new Dia()
                {
                    DiaId = 1,
                    Nombre = "Lunes",
                    Abreviatura = "L",
                },
                new Dia()
                {
                    DiaId = 2,
                    Nombre = "Martes",
                    Abreviatura = "M",
                },
                new Dia()
                {
                    DiaId = 3,
                    Nombre = "Miércoles",
                    Abreviatura = "X",
                },
                new Dia()
                {
                    DiaId = 4,
                    Nombre = "Jueves",
                    Abreviatura = "J",
                },
                new Dia()
                {
                    DiaId = 5,
                    Nombre = "Viernes",
                    Abreviatura = "V",
                },
                new Dia()
                {
                    DiaId = 6,
                    Nombre = "Sábado",
                    Abreviatura = "S",
                },
                new Dia()
                {
                    DiaId = 7,
                    Nombre = "Domingo",
                    Abreviatura = "D",
                },

            });
        }
    }
}
