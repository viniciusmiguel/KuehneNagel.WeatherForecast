using KuehneNagel.WeatherForecast.Application.Interfaces;
using KuehneNagel.WeatherForecast.Application.ViewModels;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Services;
using System;

namespace KuehneNagel.WeatherForecast.Application.Services
{
    /// <inheritdoc />
    public class WeatherForecastAppService : IWeatherForecastAppService
    {
        private readonly IWeatherForecastAggregateService WeatherForecastAggregateService;
        public WeatherForecastAppService(IWeatherForecastAggregateService weatherForecastAggregateService)
        {
            WeatherForecastAggregateService = weatherForecastAggregateService;
        }
        /// <inheritdoc />
        public WeatherForecastViewModel GetWeatherData()
        {
            var viewModel = new WeatherForecastViewModel();
            viewModel.ErrorMessage = WeatherForecastAggregateService.UpdateDataFromOnlineServices();
            viewModel.CurrentTemperature = WeatherForecastAggregateService
                .GetCurrentTemperature();
            viewModel.CurrentTemperatureMatchForecast = WeatherForecastAggregateService
                .CurrentTemperatureMatchForecast(DateTime.Now);
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
