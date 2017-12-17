
using System;
using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Services
{
    /// <summary>
    /// Represents a service that manipulate weather data 
    /// </summary>
    public interface IWeatherForecastAggregateService
    {
        /// <summary>
        /// Update data from on-line service
        /// </summary>
        /// <returns>Error message if exists</returns>
        string UpdateDataFromOnlineServices();
        /// <summary>
        /// Retrieve Temperature from database
        /// </summary>
        /// <returns>Current Temperature</returns>
        double GetCurrentTemperature();
        /// <summary>
        /// Check if temperature match forecast
        /// </summary>
        /// <returns>True if temperature match forecast</returns>
        bool CurrentTemperatureMatchForecast(DateTime dateTime);
        /// <summary>
        /// Get min day temperatures for the next 3 days
        /// </summary>
        /// <returns></returns>
        IEnumerable<double> GetMinDayTemperatures();
        /// <summary>
        /// Get min day temperatures for the next 3 days
        /// </summary>
        /// <returns></returns>
        IEnumerable<double> GetMaxDayTemperatures();
        /// <summary>
        /// Get min night temperatures for the next 3 days
        /// </summary>
        /// <returns></returns>
        IEnumerable<double> GetMinNightTemperatures();
        /// <summary>
        /// Get max night temperatures for the next 3 days
        /// </summary>
        /// <returns></returns>
        IEnumerable<double> GetMaxNightTemperatures();
        /// <summary>
        /// Get forecast Accuracy in percentage
        /// </summary>
        /// <returns></returns>
        double GetCurrentDayForecastAccuracy();
    }
}
