
using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Application.ViewModels
{
    public class WeatherForecastViewModel
    {
        public double CurrentTemperature { get; set; }

        public bool CurrentTemperatureMatchForecast { get; set; }

        public double CurrentDayForecastAccuracy { get; set; }

        public IEnumerable<double> MinDayTemperatures { get; set; }

        public IEnumerable<double> MaxDayTemperatures { get; set; }

        public IEnumerable<double> MinNightTemperatures { get; set; }

        public IEnumerable<double> MaxNightTemperatures { get; set; }

        public string ErrorMessage { get; set; }
    }
}
