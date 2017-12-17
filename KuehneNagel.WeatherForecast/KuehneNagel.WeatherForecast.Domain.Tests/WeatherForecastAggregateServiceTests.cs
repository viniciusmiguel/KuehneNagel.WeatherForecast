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
                    },
                    new Forecast()
                    {
                        Date = new DateTime(2017, 1, 2),
                        MaxDayTemperature = 2,
                        MinDayTemperature = 2,
                        MaxNightTemperature = 2,
                        MinNightTemperature = 2
                    },
                    new Forecast()
                    {
                        Date = new DateTime(2017, 1, 3),
                        MaxDayTemperature = 3,
                        MinDayTemperature = 3,
                        MaxNightTemperature = 3,
                        MinNightTemperature = 3
                    },
                    new Forecast()
                    {
                        Date = new DateTime(2017, 1, 4),
                        MaxDayTemperature = 4,
                        MinDayTemperature = 4,
                        MaxNightTemperature = 4,
                        MinNightTemperature = 4
                    },

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
                        AirTemperature=0,
                        Date= new DateTime(2017,1,1,4,0,0),
                    },
                    new Observation()
                    {
                        AirTemperature=5,
                        Date= new DateTime(2017,1,1,7,0,0),
                    },
                    new Observation()
                    {
                        AirTemperature=6,
                        Date= new DateTime(2017,1,1,13,0,0),
                    },
                    new Observation()
                    {
                        AirTemperature=1,
                        Date= new DateTime(2017,1,1,18,30,0),
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
                        AirTemperature=0,
                        Date= new DateTime(2016,1,1,4,0,0),
                    },
                    new Observation()
                    {
                        AirTemperature=0,
                        Date= new DateTime(2017,1,1,4,0,0),
                    },
                    new Observation()
                    {
                        AirTemperature=5,
                        Date= new DateTime(2017,1,1,7,0,0),
                    },
                    new Observation()
                    {
                        AirTemperature=6,
                        Date= new DateTime(2017,1,1,13,0,0),
                    },
                    new Observation()
                    {
                        AirTemperature=1,
                        Date= new DateTime(2017,1,1,18,30,0),
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
            Assert.IsTrue(aggregateService.CurrentTemperatureMatchForecast(new DateTime(2017,1,1,12,0,0)),
                "Current Day Temperature Status Invalid");
            Assert.IsFalse(aggregateService.CurrentTemperatureMatchForecast(new DateTime(2017, 1, 1, 23, 0, 0)),
                "Current Night Temperature Status Invalid");
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
            Assert.IsTrue(aggregateService.GetCurrentDayForecastAccuracy() == 50,
                "Accuracy calculation does not match");
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
            Assert.IsTrue(aggregateService.GetCurrentTemperature() == 1,
                "Current temperature does not match");
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
            var maxDayTemp = aggregateService.GetMaxDayTemperatures().GetEnumerator();
            maxDayTemp.MoveNext();
            Assert.IsTrue(maxDayTemp.Current == 5);
            maxDayTemp.MoveNext();
            Assert.IsTrue(maxDayTemp.Current == 2);
            maxDayTemp.MoveNext();
            Assert.IsTrue(maxDayTemp.Current == 3);
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
            var maxNightTemp = aggregateService.GetMaxNightTemperatures().GetEnumerator();
            maxNightTemp.MoveNext();
            Assert.IsTrue(maxNightTemp.Current == 2);
            maxNightTemp.MoveNext();
            Assert.IsTrue(maxNightTemp.Current == 2);
            maxNightTemp.MoveNext();
            Assert.IsTrue(maxNightTemp.Current == 3);
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
            var minDayTemp = aggregateService.GetMinDayTemperatures().GetEnumerator();
            minDayTemp.MoveNext();
            Assert.IsTrue(minDayTemp.Current == 3);
            minDayTemp.MoveNext();
            Assert.IsTrue(minDayTemp.Current == 2);
            minDayTemp.MoveNext();
            Assert.IsTrue(minDayTemp.Current == 3);
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
            var minNightTemp = aggregateService.GetMinNightTemperatures().GetEnumerator();

            minNightTemp.MoveNext();
            Assert.IsTrue(minNightTemp.Current == 1);
            minNightTemp.MoveNext();
            Assert.IsTrue(minNightTemp.Current == 2);
            minNightTemp.MoveNext();
            Assert.IsTrue(minNightTemp.Current == 3);
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
