using System;
using System.Collections.Generic;
using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Services;
using KuehneNagel.WeatherForecast.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KuehneNagel.WeatherForecast.Domain.Tests
{
    [TestClass]
    public class WeatherForecastAggregateServiceTests
    {
        private class ForecastRepositoryMock : IForecastRepository
        {
            public void AddOrUpdate(Forecast forecast)
            {
                
            }

            public void Create(Forecast data)
            {
                
            }

            public void Delete(int index)
            {
                
            }

            public Forecast GetTodayForecast()
            {
                return new Forecast() {
                    Date =new DateTime(2017,1,1),
                    MaxDayTemperature =5,
                    MinDayTemperature =3,
                    MaxNightTemperature =2,
                    MinNightTemperature =1 };
            }

            public Forecast Read(int index)
            {
                return new Forecast()
                {
                    Id = index,
                    Date = new DateTime(2017, 1, 1),
                    MaxDayTemperature = 5,
                    MinDayTemperature = 3,
                    MaxNightTemperature = 2,
                    MinNightTemperature = 1
                };
            }

            public IEnumerable<Forecast> ReadAll()
            {
                return new List<Forecast>() {
                    new Forecast()
                    {
                        Date = new DateTime(2017, 1, 1),
                        MaxDayTemperature = 5,
                        MinDayTemperature = 3,
                        MaxNightTemperature = 2,
                        MinNightTemperature = 1
                    }
                };    
            }

            public void Update(Forecast data)
            {
                
            }
        }
        private class ObservationRepositoryMock : IObservationRepository
        {
            public void AddOrUpdate(Observation observation)
            {                
            }

            public void Create(Observation data)
            {
            }

            public void Delete(int index)
            {
            }

            public IEnumerable<Observation> GetAllObservationsFromToday()
            {
                return new List<Observation>() {
                    new Observation()
                    {
                        AirTemperature=4,
                        Date= new DateTime(2017,1,1),
                    }
                };
            }

            public Observation Read(int index)
            {
                return new Observation()
                {
                    Id = index,
                    AirTemperature = 4,
                    Date = new DateTime(2017, 1, 1),
                };
            }

            public IEnumerable<Observation> ReadAll()
            {
                return new List<Observation>() {
                    new Observation()
                    {
                        AirTemperature=4,
                        Date= new DateTime(2017,1,1),
                    }
                };
            }

            public void Update(Observation data)
            {
            }
        }
        private class ForecastsServiceRepositoryMock : IForecastsServiceRepository
        {
            public string RawData { set; get; }

            public forecasts Data { get; set; }

            public void GetServiceData()
            {
                
            }

            public forecasts Parse()
            {
                Data = new forecasts();
                return Data;
            }
        }
        private class ObservationsServiceRepositoryMock : IObservationsServiceRepository
        {
            public string RawData { set; get; }

            public observations Data { get; set; }

            public void GetServiceData()
            {
                
            }

            public observationsStation GetStationData(string placeName)
            {
                return new observationsStation() { };
            }

            public observations Parse()
            {
                Data = new observations();
                return Data;
            }
        }
        [TestMethod]
        public void AggregateService_CurrentTemperatureMatchForecast()
        {
            IForecastRepository forecastRepository = new ForecastRepositoryMock();
            IObservationRepository observationRepository = new ObservationRepositoryMock();
            IForecastsServiceRepository forecastsServiceRepository = new ForecastsServiceRepositoryMock();
            IObservationsServiceRepository observationsServiceRepository = new ObservationsServiceRepositoryMock();
            IWeatherForecastAggregateService aggregateService = new WeatherForecastAggregateService(
                forecastRepository, 
                observationRepository,
                forecastsServiceRepository,
                observationsServiceRepository);
            aggregateService.CurrentTemperatureMatchForecast();
        }
        [TestMethod]
        public void AggregateService_GetCurrentDayForecastAccuracy()
        {
            IForecastRepository forecastRepository = new ForecastRepositoryMock();
            IObservationRepository observationRepository = new ObservationRepositoryMock();
            IForecastsServiceRepository forecastsServiceRepository = new ForecastsServiceRepositoryMock();
            IObservationsServiceRepository observationsServiceRepository = new ObservationsServiceRepositoryMock();
            IWeatherForecastAggregateService aggregateService = new WeatherForecastAggregateService(
                forecastRepository,
                observationRepository,
                forecastsServiceRepository,
                observationsServiceRepository);
            aggregateService.GetCurrentDayForecastAccuracy();
        }
        [TestMethod]
        public void AggregateService_GetCurrentTemperature()
        {
            IForecastRepository forecastRepository = new ForecastRepositoryMock();
            IObservationRepository observationRepository = new ObservationRepositoryMock();
            IForecastsServiceRepository forecastsServiceRepository = new ForecastsServiceRepositoryMock();
            IObservationsServiceRepository observationsServiceRepository = new ObservationsServiceRepositoryMock();
            IWeatherForecastAggregateService aggregateService = new WeatherForecastAggregateService(
                forecastRepository,
                observationRepository,
                forecastsServiceRepository,
                observationsServiceRepository);
            aggregateService.GetCurrentTemperature();
        }
        [TestMethod]
        public void AggregateService_GetMaxDayTemperatures()
        {
            IForecastRepository forecastRepository = new ForecastRepositoryMock();
            IObservationRepository observationRepository = new ObservationRepositoryMock();
            IForecastsServiceRepository forecastsServiceRepository = new ForecastsServiceRepositoryMock();
            IObservationsServiceRepository observationsServiceRepository = new ObservationsServiceRepositoryMock();
            IWeatherForecastAggregateService aggregateService = new WeatherForecastAggregateService(
                forecastRepository,
                observationRepository,
                forecastsServiceRepository,
                observationsServiceRepository);
            aggregateService.GetMaxDayTemperatures();
        }
        [TestMethod]
        public void AggregateService_GetMaxNightTemperatures()
        {
            IForecastRepository forecastRepository = new ForecastRepositoryMock();
            IObservationRepository observationRepository = new ObservationRepositoryMock();
            IForecastsServiceRepository forecastsServiceRepository = new ForecastsServiceRepositoryMock();
            IObservationsServiceRepository observationsServiceRepository = new ObservationsServiceRepositoryMock();
            IWeatherForecastAggregateService aggregateService = new WeatherForecastAggregateService(
                forecastRepository,
                observationRepository,
                forecastsServiceRepository,
                observationsServiceRepository);
            aggregateService.GetMaxNightTemperatures();
        }
        [TestMethod]
        public void AggregateService_GetMinDayTemperatures()
        {
            IForecastRepository forecastRepository = new ForecastRepositoryMock();
            IObservationRepository observationRepository = new ObservationRepositoryMock();
            IForecastsServiceRepository forecastsServiceRepository = new ForecastsServiceRepositoryMock();
            IObservationsServiceRepository observationsServiceRepository = new ObservationsServiceRepositoryMock();
            IWeatherForecastAggregateService aggregateService = new WeatherForecastAggregateService(
                forecastRepository,
                observationRepository,
                forecastsServiceRepository,
                observationsServiceRepository);
            aggregateService.GetMinDayTemperatures();

        }
        [TestMethod]
        public void AggregateService_GetMinNightTemperatures()
        {
            IForecastRepository forecastRepository = new ForecastRepositoryMock();
            IObservationRepository observationRepository = new ObservationRepositoryMock();
            IForecastsServiceRepository forecastsServiceRepository = new ForecastsServiceRepositoryMock();
            IObservationsServiceRepository observationsServiceRepository = new ObservationsServiceRepositoryMock();
            IWeatherForecastAggregateService aggregateService = new WeatherForecastAggregateService(
                forecastRepository,
                observationRepository,
                forecastsServiceRepository,
                observationsServiceRepository);
            aggregateService.GetMinNightTemperatures();
        }
        [TestMethod]
        public void AggregateService_UpdateDataFromOnlineServices()
        {
            IForecastRepository forecastRepository = new ForecastRepositoryMock();
            IObservationRepository observationRepository = new ObservationRepositoryMock();
            IForecastsServiceRepository forecastsServiceRepository = new ForecastsServiceRepositoryMock();
            IObservationsServiceRepository observationsServiceRepository = new ObservationsServiceRepositoryMock();
            IWeatherForecastAggregateService aggregateService = new WeatherForecastAggregateService(
                forecastRepository,
                observationRepository,
                forecastsServiceRepository,
                observationsServiceRepository);
            aggregateService.UpdateDataFromOnlineServices();
        }
    }
}
