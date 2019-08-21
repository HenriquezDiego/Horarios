using System.Collections.Generic;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class HorarioConfig : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.HasData(GenerarHorarios());
        }

        public static IEnumerable<Horario> GenerarHorarios()
        {
           return new List<Horario>()
            {

                new Horario()
                {
                    HorarioId = 1,
                    Descripcion = "Lunes a viernes de 6:00 am a 2:00 pm" +
                                  "Sabado de 6:00 am a 10:00 am y 6:00 pm 6:00 am",
                    Abreviatura = "I",
                    Alias = "Azul"
                },
                new Horario()
                {
                    HorarioId = 2,
                    Descripcion = "Lunes a viernes de 2:00 am a 10:00 pm" +
                                  "Sabado de 10:00 am a 2:00 am y Domingo 6:00 am 6:00 pm",
                    Abreviatura = "II",
                    Alias = "Rojo",
                },
                new Horario()
                {
                    HorarioId = 3,
                    Descripcion = "Lunes a viernes de 10:00 pm a 6:00 am" +
                                  "Sabado de 2:00 pm a 6:00 am y Domingo 6:00 pm 6:00 am",
                    Abreviatura = "III",
                    Alias = "Negro",
                }
            };
        }
    }
}
