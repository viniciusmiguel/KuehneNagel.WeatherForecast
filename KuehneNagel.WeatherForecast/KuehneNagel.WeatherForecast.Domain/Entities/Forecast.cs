using System;

namespace KuehneNagel.WeatherForecast.Domain.Entities
{
    public class Forecast
    {
        public Forecast() { }

        public DateTime Id { get; set; }

        public double MinDayTemperature { get; set; }

        public double MaxDayTemperature { get; set; }

        public double MinNightTemperature { get; set; }

        public double MaxNightTemperature { get; set; }
    }
}
