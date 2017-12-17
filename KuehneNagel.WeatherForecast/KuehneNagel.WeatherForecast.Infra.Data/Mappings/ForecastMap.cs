using KuehneNagel.WeatherForecast.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KuehneNagel.WeatherForecast.Infra.Data.Mappings
{
    public class ForecastMap : IEntityTypeConfiguration<Forecast>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Forecast> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnType("int");

            builder.Property(c => c.Date)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.MinDayTemperature)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(c => c.MaxDayTemperature)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(c => c.MinNightTemperature)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(c => c.MaxNightTemperature)
                .HasColumnType("float")
                .IsRequired();
        }
    }
}
