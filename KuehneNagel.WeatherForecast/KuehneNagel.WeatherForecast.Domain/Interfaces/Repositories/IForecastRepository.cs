using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Represents a repository of entity Forecast
    /// </summary>
    public interface IForecastRepository : IRepositoryBase<Forecast, int>
    {
        /// <summary>
        /// Add or update a row
        /// </summary>
        /// <param name="forecast">the row data to be updated</param>
        void AddOrUpdate(Forecast forecast);
        /// <summary>
        /// The forecast from today
        /// </summary>
        /// <returns>Today forecast</returns>
        Forecast GetTodayForecast();
    }
}
