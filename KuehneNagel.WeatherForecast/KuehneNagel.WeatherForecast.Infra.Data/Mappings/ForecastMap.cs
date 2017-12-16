﻿using KuehneNagel.WeatherForecast.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KuehneNagel.WeatherForecast.Infra.Data.Mappings
{
    public class ForecastMap : IEntityTypeConfiguration<Forecast>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Forecast> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .IsRowVersion()
                .IsRequired();

            builder.Property(c => c.MinDayTemperature)
                .HasColumnType("smallmoney")
                .IsRequired();

            builder.Property(c => c.MaxDayTemperature)
                .HasColumnType("smallmoney")
                .IsRequired();

            builder.Property(c => c.MinNightTemperature)
                .HasColumnType("smallmoney")
                .IsRequired();

            builder.Property(c => c.MaxNightTemperature)
                .HasColumnType("smallmoney")
                .IsRequired();
        }
    }
}
