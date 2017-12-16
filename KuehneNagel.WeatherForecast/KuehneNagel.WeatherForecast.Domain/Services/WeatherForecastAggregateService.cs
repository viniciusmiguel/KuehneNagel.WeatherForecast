using System;
using System.Collections.Generic;
using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Services;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace KuehneNagel.WeatherForecast.Domain.Services
{
    public class WeatherForecastAggregateService : IWeatherForecastAggregateService
    {
        private readonly IForecastRepository ForecastRepository;
        private readonly IObservationRepository ObservationRepository;
        private readonly IForecastsServiceRepository ForecastsServiceRepository;
        private readonly IObservationsServiceRepository ObservationsServiceRepository;
        public WeatherForecastAggregateService(
            IForecastRepository forecastRepository,
            IObservationRepository observationRepository,
            IForecastsServiceRepository forecastsServiceRepository,
            IObservationsServiceRepository observationsServiceRepository)
        {
            ForecastRepository = forecastRepository;
            ObservationRepository = observationRepository;
            ForecastsServiceRepository = forecastsServiceRepository;
            ObservationsServiceRepository = observationsServiceRepository;
        }
        public bool UpdateDataFromOnlineServices()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true)
                    .Build();

                string place = config.GetSection("Place").Value != null ?
                               config.GetSection("Place").Value : 
                               "Harku";

                string station = config.GetSection("Station").Value != null ?
                               config.GetSection("Station").Value :
                               "Tallinn-Harku";

                var observationsStation = ObservationsServiceRepository.GetStationData(station);
                forecastsForecast[] forecasts = (forecastsForecast[])ForecastsServiceRepository.Parse().Items;

                var observation = new Observation();

                observation.AirTemperature = double.Parse(observationsStation.airtemperature);
                observation.Id = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
                observation.Id.AddSeconds(double.Parse(ObservationsServiceRepository.Data.timestamp));

                ObservationRepository.AddOrUpdate(observation);

                foreach(var forecastPlace in forecasts)
                {
                    var forecast = new Forecast();
                    forecast.Id = DateTime.Parse(forecastPlace.date);
                    //These temperatures are regional
                    forecast.MinDayTemperature = double.Parse(forecastPlace.day[0].tempmin);
                    forecast.MaxNightTemperature = double.Parse(forecastPlace.night[0].tempmax);
                    //These temperatures are place specific
                    forecast.MaxDayTemperature = double.Parse(
                        (from p in forecastPlace.day[0].place
                         where p.name.Equals(place)
                         select p.tempmax).FirstOrDefault());
                    forecast.MinNightTemperature = double.Parse(
                        (from p in forecastPlace.night[0].place
                        where p.name.Equals(place)
                        select p.tempmin).FirstOrDefault());

                    ForecastRepository.AddOrUpdate(forecast);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool CurrentTemperatureMatchForecast()
        {
            //Assumption day start 6:00 end 18:00
            if(DateTime.Now.Hour > 6 && DateTime.Now.Hour < 18)
            {
                if (GetCurrentTemperature() >= ForecastRepository.GetTodayForecast().MinDayTemperature &&
                    GetCurrentTemperature() <= ForecastRepository.GetTodayForecast().MaxDayTemperature)
                    return true;
                else
                    return false;
            }
            else
            {
                if (GetCurrentTemperature() >= ForecastRepository.GetTodayForecast().MinNightTemperature &&
                    GetCurrentTemperature() <= ForecastRepository.GetTodayForecast().MaxNightTemperature)
                    return true;
                else
                    return false;
            }
        }

        public double GetCurrentDayForecastAccuracy()
        {
            return 100;
        }

        public double GetCurrentTemperature()
        {
            return ObservationRepository.ReadAll().Last().AirTemperature;
        }

        public IEnumerable<double> GetMaxDayTemperatures()
        {
            return from fore in ForecastRepository.ReadAll().TakeLast(4)
                   select fore.MaxDayTemperature;
        }

        public IEnumerable<double> GetMaxNightTemperatures()
        {
            return from fore in ForecastRepository.ReadAll().TakeLast(4)
                   select fore.MaxNightTemperature;
        }

        public IEnumerable<double> GetMinDayTemperatures()
        {
            return from fore in ForecastRepository.ReadAll().TakeLast(4)
                   select fore.MinDayTemperature;
        }

        public IEnumerable<double> GetMinNightTemperatures()
        {
            return from fore in ForecastRepository.ReadAll().TakeLast(4)
                   select fore.MinDayTemperature;
        }

    }
}
