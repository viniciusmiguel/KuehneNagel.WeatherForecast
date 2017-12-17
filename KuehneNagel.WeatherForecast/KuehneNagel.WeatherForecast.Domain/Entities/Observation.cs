using System;
using System.ComponentModel.DataAnnotations;

namespace KuehneNagel.WeatherForecast.Domain.Entities
{
    public class Observation
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double AirTemperature { get; set; }
    }
}
