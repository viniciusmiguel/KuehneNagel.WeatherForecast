using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    public interface IObservationsServiceRepository :
        IXmlRepositoryBase<observations>,
        IServiceRepositoryBase<observations>
    {

    }
}
