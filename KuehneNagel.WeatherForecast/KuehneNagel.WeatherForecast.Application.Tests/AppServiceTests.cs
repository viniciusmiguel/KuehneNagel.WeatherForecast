using System.Collections.Generic;
using KuehneNagel.WeatherForecast.Application.Interfaces;
using KuehneNagel.WeatherForecast.Application.Services;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KuehneNagel.WeatherForecast.Application.Tests
{
    [TestClass]
    public class AppServiceTests
    {
        private class weatherAggregateServiceMock : IWeatherForecastAggregateService
        {
            public bool CurrentTemperatureMatchForecast()
            {
                return true;
            }

            public double GetCurrentDayForecastAccuracy()
            {
                return 50;
            }

            public double GetCurrentTemperature()
            {
                return 55.55;
            }

            public IEnumerable<double> GetMaxDayTemperatures()
            {
                return new List<double>() { 1, 2, 3 };
            }

            public IEnumerable<double> GetMaxNightTemperatures()
            {
                return new List<double>() { 4, 5, 6 };
            }

            public IEnumerable<double> GetMinDayTemperatures()
            {
                return new List<double>() { 7, 8, 9 };
            }

            public IEnumerable<double> GetMinNightTemperatures()
            {
                return new List<double>() { 10, 11, 12 };
            }

            public string UpdateDataFromOnlineServices()
            {
                return "Message";
            }
        }
        [TestMethod]
        public void GetWeatherData()
        {
            var mock = new weatherAggregateServiceMock();
            IWeatherForecastAppService  appService = new  WeatherForecastAppService(mock);
            var viewModel = appService.GetWeatherData();
            Assert.IsTrue(mock.CurrentTemperatureMatchForecast() == viewModel.CurrentTemperatureMatchForecast,
                "Current Temperature Match Forecast Not Valid!");

            Assert.IsTrue(mock.GetCurrentDayForecastAccuracy() == viewModel.CurrentDayForecastAccuracy,
                "Current Day Forecast Accuracy Not Valid!");

            Assert.IsTrue(mock.GetCurrentTemperature() == viewModel.CurrentTemperature,
                "Current Temperature Not Valid!");

            var maxDay = viewModel.MaxDayTemperatures.GetEnumerator();
            maxDay.MoveNext();
            Assert.IsTrue(maxDay.Current == 1,
                "Get Max Day Temperatures Not Valid!");

            var maxNight = viewModel.MaxNightTemperatures.GetEnumerator();
            maxNight.MoveNext();
            Assert.IsTrue(maxNight.Current == 4,
                "Get Max Night Temperatures Not Valid!");

            var minDay = viewModel.MinDayTemperatures.GetEnumerator();
            minDay.MoveNext();
            Assert.IsTrue(minDay.Current == 7,
                "Get Min Day Temperatures Not Valid!");

            var minNight = viewModel.MinNightTemperatures.GetEnumerator();
            minNight.MoveNext();
            Assert.IsTrue(minNight.Current == 10,
                "Get Min Night Temperatures Not Valid!");

        }
    }
}
