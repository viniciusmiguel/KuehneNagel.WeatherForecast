using System;
using System.ComponentModel.DataAnnotations;

namespace KuehneNagel.WeatherForecast.Domain.Entities
{
    public class Forecast
    {
        public Forecast() { }

        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double MinDayTemperature { get; set; }

        public double MaxDayTemperature { get; set; }

        public double MinNightTemperature { get; set; }

        public double MaxNightTemperature { get; set; }
    }
}
