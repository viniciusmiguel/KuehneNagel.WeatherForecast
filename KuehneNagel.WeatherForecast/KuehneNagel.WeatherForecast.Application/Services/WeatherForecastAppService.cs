using KuehneNagel.WeatherForecast.Application.Interfaces;
using KuehneNagel.WeatherForecast.Application.ViewModels;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Services;

namespace KuehneNagel.WeatherForecast.Application.Services
{
    public class WeatherForecastAppService : IWeatherForecastAppService
    {
        private readonly IWeatherForecastAggregateService WeatherForecastAggregateService;
        public WeatherForecastAppService(IWeatherForecastAggregateService weatherForecastAggregateService)
        {
            WeatherForecastAggregateService = weatherForecastAggregateService;
        }
        public WeatherForecastViewModel GetWeatherData()
        {
            var viewModel = new WeatherForecastViewModel();
            WeatherForecastAggregateService.UpdateDataFromOnlineServices();
            viewModel.CurrentTemperature = WeatherForecastAggregateService
                .GetCurrentTemperature();
            viewModel.CurrentTemperatureMatchForecast = WeatherForecastAggregateService
                .CurrentTemperatureMatchForecast();
            viewModel.CurrentDayForecastAccuracy = WeatherForecastAggregateService
                .GetCurrentDayForecastAccuracy();
            viewModel.MinDayTemperatures = WeatherForecastAggregateService
                .GetMinDayTemperatures();
            viewModel.MaxDayTemperatures = WeatherForecastAggregateService
                .GetMaxDayTemperatures();
            viewModel.MinNightTemperatures = WeatherForecastAggregateService
                .GetMinNightTemperatures();
            viewModel.MaxNightTemperatures = WeatherForecastAggregateService
                .GetMaxNightTemperatures();
            return viewModel;
        }
    }
}
