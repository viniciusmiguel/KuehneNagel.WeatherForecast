using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KuehneNagel.WeatherForecast.Infra.Data.Tests
{
    [TestClass]
    public class XmlRepositoryTest
    {
        [TestMethod]
        public void GetForecastDataFromServer()
        {
            try
            {
                var repo = new ForecastsServiceRepository();
                repo.GetServiceData();
                repo.Parse();
                Assert.IsInstanceOfType(repo.Data, typeof(forecasts));
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        [TestMethod]
        public void GetObservationsDataFromServer()
        {
            try
            {
                var repo = new ObservationsServiceRepository();
                repo.GetServiceData();
                repo.Parse();
                Assert.IsInstanceOfType(repo.Data, typeof(observations));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
