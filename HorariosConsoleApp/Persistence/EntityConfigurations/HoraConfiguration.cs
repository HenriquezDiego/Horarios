using System;
using System.Collections.Generic;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class HoraConfiguration : IEntityTypeConfiguration<Hora>
    {
        public void Configure(EntityTypeBuilder<Hora> builder)
        {
            builder.HasData(new List<Hora>()
            {
                new Hora()
                {
                    HoraId = 1,
                    
                }
            });
        }

        private List<Hora> GetListHoras()
        {
            List<Hora> listHoras = new List<Hora>();
            for (var i = 0; i < 23; i++)
            {
                var  timeSpan = new TimeSpan(i,0,0);
                var newHora = new Hora()
                {
                    HoraId = i
                };
            }

            return listHoras;
        }
    }
}
