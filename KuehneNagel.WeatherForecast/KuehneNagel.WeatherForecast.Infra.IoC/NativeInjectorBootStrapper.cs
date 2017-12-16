using KuehneNagel.WeatherForecast.Application.Interfaces;
using KuehneNagel.WeatherForecast.Application.Services;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Services;
using KuehneNagel.WeatherForecast.Domain.Services;
using KuehneNagel.WeatherForecast.Infra.Data.DbContexts;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace KuehneNagel.WeatherForecast.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application - Services
            services.AddScoped<IWeatherForecastAppService, WeatherForecastAppService>();

            //Domain - Services
            services.AddScoped<IWeatherForecastAggregateService, WeatherForecastAggregateService>();

            //Infra - Data
            services.AddScoped<IForecastRepository, ForecastRepository>();
            services.AddScoped<IObservationRepository, ObservationRepository>();

            services.AddScoped<IForecastsServiceRepository, ForecastsServiceRepository>();
            services.AddScoped<IObservationsServiceRepository, ObservationsServiceRepository>();

            services.AddScoped<EfContext>();
        }
    }
}
