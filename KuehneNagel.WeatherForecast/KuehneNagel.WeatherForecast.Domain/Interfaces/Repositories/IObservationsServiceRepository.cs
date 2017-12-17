using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Represents a repository of Observation Service
    /// </summary>
    public interface IObservationsServiceRepository :
        IXmlRepositoryBase<observations>,
        IServiceRepositoryBase<observations>
    {
        /// <summary>
        /// Get observation from a station name
        /// </summary>
        /// <param name="placeName">The name of the station</param>
        /// <returns>Observation data</returns>
        observationsStation GetStationData(string placeName);
    }
}
