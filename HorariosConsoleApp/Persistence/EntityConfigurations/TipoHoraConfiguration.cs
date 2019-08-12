using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorariosConsoleApp.Persistence.EntityConfigurations
{
    public class TipoHoraConfiguration : IEntityTypeConfiguration<TipoHora>
    {
        public void Configure(EntityTypeBuilder<TipoHora> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
