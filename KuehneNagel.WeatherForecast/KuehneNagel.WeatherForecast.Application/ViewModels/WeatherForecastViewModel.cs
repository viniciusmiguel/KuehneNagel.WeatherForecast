
using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Application.ViewModels
{
    public class WeatherForecastViewModel
    {
        public double CurrentTemperature { get; set; }

        public bool CurrentTemperatureMatchForecast { get; set; }

        public double CurrentDayForecastAccuracy { get; set; }

        public List<double> MinDayTemperatures { get; set; }

        public List<double> MaxDayTemperatures { get; set; }

        public List<double> MinNightTemperatures { get; set; }

        public List<double> MaxNightTemperatures { get; set; }
    }
}
