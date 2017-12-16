
using KuehneNagel.WeatherForecast.Application.ViewModels;

namespace KuehneNagel.WeatherForecast.Application.Interfaces
{
    public interface IWeatherForecastAppService
    {
        WeatherForecastViewModel GetWeatherData();
    }
}
