using KuehneNagel.WeatherForecast.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KuehneNagel.WeatherForecast.Infra.Data.Mappings
{
    public class ForecastMap : IEntityTypeConfiguration<Forecast>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Forecast> builder)
        {
            //TODO: DbMapConfig
            //builder.Property(c => c.)
            //    .HasColumnName("Id");

            //builder.Property(c => c.)
            //    .HasColumnType("varchar(100)")
            //    .HasMaxLength(100)
            //    .IsRequired();

            //builder.Property(c => c.)
            //    .HasColumnType("varchar(100)")
            //    .HasMaxLength(11)
            //    .IsRequired();
        }
    }
}
