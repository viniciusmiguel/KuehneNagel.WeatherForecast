using KuehneNagel.WeatherForecast.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuehneNagel.WeatherForecast.Infra.Data.Mappings
{
    public class ObservationMap : IEntityTypeConfiguration<Observation>
    {
        public void Configure(EntityTypeBuilder<Observation> builder)
        {
            //TODO: DbMapConfig
        }
    }
}
