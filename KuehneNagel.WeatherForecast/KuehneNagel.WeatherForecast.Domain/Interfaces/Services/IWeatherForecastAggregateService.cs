
using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Services
{
    public interface IWeatherForecastAggregateService
    {
        bool UpdateDataFromOnlineServices();
        double GetCurrentTemperature();
        bool CurrentTemperatureMatchForecast();
        IEnumerable<double> GetMinDayTemperatures();
        IEnumerable<double> GetMaxDayTemperatures();
        IEnumerable<double> GetMinNightTemperatures();
        IEnumerable<double> GetMaxNightTemperatures();
        double GetCurrentDayForecastAccuracy();
    }
}
