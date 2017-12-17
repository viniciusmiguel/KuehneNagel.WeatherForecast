using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Represents a Repository from Forecast Service
    /// </summary>
    public interface IForecastsServiceRepository : 
        IXmlRepositoryBase<forecasts>, 
        IServiceRepositoryBase<forecasts>
    {

    }
}
