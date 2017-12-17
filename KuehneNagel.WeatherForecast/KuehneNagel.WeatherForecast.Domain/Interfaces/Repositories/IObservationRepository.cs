using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;
using KuehneNagel.WeatherForecast.Domain.Entities;
using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Represents a repository of Observation entity
    /// </summary>
    public interface IObservationRepository : IRepositoryBase<Observation, int>      
    {
        /// <summary>
        /// Add or Update Observation entity row
        /// </summary>
        /// <param name="observation"></param>
        void AddOrUpdate(Observation observation);
        /// <summary>
        /// Get all observations from today
        /// </summary>
        /// <returns>List of observations</returns>
        IEnumerable<Observation> GetAllObservationsFromToday();
    }
}
