using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;
using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    public interface IForecastsServiceRepository : 
        IXmlRepositoryBase<forecasts>, 
        IServiceRepositoryBase<forecasts>
    {

    }
}
