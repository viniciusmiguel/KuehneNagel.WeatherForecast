using System;
using System.Collections.Generic;
using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Services;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using KuehneNagel.WeatherForecast.Domain.Extensions;

namespace KuehneNagel.WeatherForecast.Domain.Services
{
    /// <inheritdoc />
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
        /// <inheritdoc />
        public string UpdateDataFromOnlineServices()
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
                ForecastsServiceRepository.GetServiceData();
                var forecasts = ForecastsServiceRepository.Parse().Items;

                var observation = new Observation
                {
                    AirTemperature = double.Parse(observationsStation.airtemperature),
                    Date = new DateTime().FromUnixTimeStamp(double.Parse(ObservationsServiceRepository.Data.timestamp))
                };

                ObservationRepository.AddOrUpdate(observation);

                foreach (var forecastPlaceObj in forecasts)
                {
                    forecastsForecast forecastPlace = (forecastsForecast) forecastPlaceObj;
                    var forecast = new Forecast();
                    forecast.Date = DateTime.Parse(forecastPlace.date);
                    //These temperatures are regional
                    forecast.MinDayTemperature = double.Parse(forecastPlace.day[0].tempmin);
                    forecast.MaxNightTemperature = double.Parse(forecastPlace.night[0].tempmax);
                    //These temperatures are place specific but not always available 
                    try
                    {
                        forecast.MaxDayTemperature = double.Parse(
                        (from p in forecastPlace.day[0].place
                         where p.name.Equals(place)
                         select p.tempmax).FirstOrDefault());
                    }
                    catch
                    {
                        forecast.MaxDayTemperature = double.Parse(forecastPlace.day[0].tempmax);
                    }
                    try
                    {
                        forecast.MinNightTemperature = double.Parse(
                        (from p in forecastPlace.night[0].place
                         where p.name.Equals(place)
                         select p.tempmin).FirstOrDefault());
                    }
                    catch
                    {
                        forecast.MinNightTemperature = double.Parse(forecastPlace.night[0].tempmin);
                    }
                    ForecastRepository.AddOrUpdate(forecast);
                }
            }
            catch(System.Net.WebException)
            {
                return "The weather service is off-line";
            }
            catch(Exception e)
            {
                return "There was an Internal error when the server tried to update the weather information: \n" + e.Message;
            }
            return "";
        }
        /// <inheritdoc />
        public bool CurrentTemperatureMatchForecast(DateTime dateTime)
        {
            //Assumption if there's no data return true
            if (ForecastRepository.GetTodayForecast() == null)
                return true;

            //Assumption day start 6:00, end 18:00
            if (dateTime.Hour >= 6 && dateTime.Hour < 18)
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
        /// <inheritdoc />
        public double GetCurrentDayForecastAccuracy()
        {
            var forecast = ForecastRepository.GetTodayForecast();
            var observations = ObservationRepository.GetAllObservationsFromToday();
            var numberOfObservations = observations.Count();

            if (numberOfObservations == 0) return 0;

            var numberOfObservationsMatchingForecast = 0;
            foreach (var observation in observations)
                if (observation.AirTemperature >= forecast.MinNightTemperature && 
                    observation.AirTemperature <= forecast.MaxDayTemperature)
                    numberOfObservationsMatchingForecast++;

            return ( numberOfObservationsMatchingForecast * 100 ) / numberOfObservations;
        }
        /// <inheritdoc />
        public double GetCurrentTemperature()
        {
            return ObservationRepository.ReadAll().Last().AirTemperature;
        }
        /// <inheritdoc />
        public IEnumerable<double> GetMaxDayTemperatures()
        {
            return (from fore in ForecastRepository.ReadAll().TakeLast(4)
                   select fore.MaxDayTemperature).Take(3);
        }
        /// <inheritdoc />
        public IEnumerable<double> GetMaxNightTemperatures()
        {
            return (from fore in ForecastRepository.ReadAll().TakeLast(4)
                   select fore.MaxNightTemperature).Take(3);
        }
        /// <inheritdoc />
        public IEnumerable<double> GetMinDayTemperatures()
        {
            return (from fore in ForecastRepository.ReadAll().TakeLast(4)
                   select fore.MinDayTemperature).Take(3);
        }
        /// <inheritdoc />
        public IEnumerable<double> GetMinNightTemperatures()
        {
            return (from fore in ForecastRepository.ReadAll().TakeLast(4)
                   select fore.MinNightTemperature).Take(3);
        }

    }
}
