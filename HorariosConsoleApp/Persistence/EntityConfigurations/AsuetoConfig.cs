using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class AsuetoConfig : IEntityTypeConfiguration<Asueto>
    {
        public void Configure(EntityTypeBuilder<Asueto> builder)
        {
            builder.HasData(new List<Asueto>
            {
                new Asueto
                {
                    AsuetoId=1,
                    Descripcion="Primero de enero",
                    Fecha= new DateTime(2019,1,1)
                },
                new Asueto
                {
                    AsuetoId=2,
                    Descripcion="Dos de enero",
                    Fecha= new DateTime(2019,1,2)
                },
                new Asueto
                {
                    AsuetoId=3,
                    Descripcion="Dia del trabajo",
                    Fecha= new DateTime(2019,5,1)
                },
                new Asueto
                {
                    AsuetoId=4,
                    Descripcion="Dia de la Madre",
                    Fecha= new DateTime(2019,5,10)
                },
                new Asueto
                {
                    AsuetoId=5,
                    Descripcion="Fiesta patronal Santa Ana",
                    Fecha= new DateTime(2019,7,26)
                },
                new Asueto
                {
                    AsuetoId=6,
                    Descripcion="Fiesta titular nacional",
                    Fecha= new DateTime(2019,8,5)
                },
                new Asueto
                {
                    AsuetoId=7,
                    Descripcion="Fiesta titular nacional",
                    Fecha= new DateTime(2019,8,6)
                },
                new Asueto
                {
                    AsuetoId=8,
                    Descripcion="Dia de la independencia",
                    Fecha= new DateTime(2019,9,15)
                },
                new Asueto
                {
                    AsuetoId=9,
                    Descripcion="Dia de los fieles difuntos",
                    Fecha= new DateTime(2019,11,2)
                },
                new Asueto
                {
                    AsuetoId=10,
                    Descripcion="Noche buena",
                    Fecha= new DateTime(2019,12,24)
                },
                new Asueto
                {
                    AsuetoId=11,
                    Descripcion="Navidad",
                    Fecha= new DateTime(2019,12,25)
                },
                new Asueto
                {
                    AsuetoId=12,
                    Descripcion="Fin de año",
                    Fecha= new DateTime(2019,12,25)
                }

            });
        }
    }
}
