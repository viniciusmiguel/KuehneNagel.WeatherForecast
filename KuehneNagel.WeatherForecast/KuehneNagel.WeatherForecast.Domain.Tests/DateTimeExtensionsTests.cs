using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KuehneNagel.WeatherForecast.Domain.Extensions;

namespace KuehneNagel.WeatherForecast.Domain.Tests
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void TestConversion()
        {
            var dateTime = new DateTime().FromUnixTimeStamp(0);
            Assert.IsTrue(dateTime.Year == 1970 && dateTime.Month == 1 && dateTime.Day == 1);
            dateTime = new DateTime().FromUnixTimeStamp(1483228800);
            Assert.IsTrue(dateTime.Year == 2017 && dateTime.Month == 1 && dateTime.Day == 1);
        }
    }
}
