using System.Collections.Generic;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class TipoHoraConfiguration : IEntityTypeConfiguration<TipoHora>
    {
        public void Configure(EntityTypeBuilder<TipoHora> builder)
        {
            builder.HasData(new List<TipoHora>()
            {
                new TipoHora()
                {
                    TipoHoraId = 1,
                    Nombre = "Hora Extra Ordinaria Diurna",
                    PorcentajeExtra = 100
                },
                new TipoHora()
                {
                    TipoHoraId = 2,
                    Nombre = "Hora Extra  Nocturna",
                    PorcentajeExtra = 125
                },
                new TipoHora()
                {
                    TipoHoraId = 3,
                    Nombre = "Hora Ordinaria Nocturana",
                    PorcentajeExtra = 25
                },
                new TipoHora()
                {
                    TipoHoraId = 4,
                    Nombre = "Domingo Hora Ordinaria Diurna",
                    PorcentajeExtra = 300
                },
                new TipoHora()
                {
                    TipoHoraId = 5,
                    Nombre = "Hora Ordinaria Diura",
                    PorcentajeExtra = 0
                }
            });
        }
    }
}
