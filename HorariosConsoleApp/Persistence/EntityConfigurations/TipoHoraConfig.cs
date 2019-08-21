using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class TipoHoraConfig : IEntityTypeConfiguration<TipoHora>
    {
        public void Configure(EntityTypeBuilder<TipoHora> builder)
        {
            builder.HasData(new List<TipoHora>()
            {
              
                new TipoHora()
                {
                    TipoHoraId = 1,
                    Nombre = "Hora Ordinaria Diura",
                    PorcentajeExtra = 0,
                    EsNocturna = false,
                    
                },
                new TipoHora()
                {
                    TipoHoraId = 2,
                    Nombre = "Hora Ordinaria Nocturna",
                    PorcentajeExtra = 25,
                    EsNocturna = true
                },
                new TipoHora()
                {
                    TipoHoraId = 3,
                    Nombre = "Hora Extra Diura",
                    PorcentajeExtra = 200,
                    EsNocturna = false
                },
                new TipoHora()
                {
                    TipoHoraId = 4,
                    Nombre = "Hora Extra Nocturna",
                    PorcentajeExtra = 250,
                    EsNocturna = true
                },
                new TipoHora()
                {
                    TipoHoraId = 5,
                    Nombre = "Hora Ordinaria Diurna Sabado",
                    PorcentajeExtra = 0,
                    EsNocturna = false
                },
                new TipoHora()
                {
                    TipoHoraId = 6,
                    Nombre = "Hora Ordinaria Nocturna Sabado",
                    PorcentajeExtra = 25,
                    EsNocturna = true
                },
                new TipoHora()
                {
                    TipoHoraId = 7,
                    Nombre = "Hora Ordinaria Diurna Domingo",
                    PorcentajeExtra = 150,
                    EsNocturna = false
                },
                new TipoHora()
                {
                    TipoHoraId = 8,
                    Nombre = "Hora Ordinaria Nocturna Domingo",
                    PorcentajeExtra = 175,
                    EsNocturna = true
                },
                new TipoHora()
                {
                    TipoHoraId = 9,
                    Nombre = "Hora Extra Diurna Domingo",
                    PorcentajeExtra = 300,
                    EsNocturna = false
                },
                new TipoHora()
                {
                    TipoHoraId = 10,
                    Nombre = "Hora Extra Nocturna Domingo",
                    PorcentajeExtra = 350,
                    EsNocturna = true
                },
            });
        }
    }
}
