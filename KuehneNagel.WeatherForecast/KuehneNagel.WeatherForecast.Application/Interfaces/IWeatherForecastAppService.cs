
using KuehneNagel.WeatherForecast.Application.ViewModels;

namespace KuehneNagel.WeatherForecast.Application.Interfaces
{
    /// <summary>
    /// Service Implementation of IWeatherForecastAppService
    /// </summary>
    public interface IWeatherForecastAppService
    {
        /// <summary>
        /// Acquire data from the weather web-server, stores the information in the database and compute data
        /// </summary>
        /// <returns>Weather Forecast Data</returns>
        WeatherForecastViewModel GetWeatherData();
    }
}
