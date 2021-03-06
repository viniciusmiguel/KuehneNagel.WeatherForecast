﻿using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace KuehneNagel.WeatherForecast.Infra.Data.DbContexts
{
    public class EfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true)
            .Build();
            optionsBuilder.UseSqlServer(
                config.GetConnectionString("DefaultConnection") != null ?
                config.GetConnectionString("DefaultConnection") :
                "data source=.\\SQLEXPRESS;Integrated Security=SSPI;database = weather;User Instance = false; MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ObservationMap());
            modelBuilder.ApplyConfiguration(new ForecastMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<Observation> Observations { get; set; }
    }
}
