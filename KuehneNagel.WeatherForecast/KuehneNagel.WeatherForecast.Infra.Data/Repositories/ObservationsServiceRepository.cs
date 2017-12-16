
using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    public class ObservationsServiceRepository : XmlRepositoryBase<observations>, IObservationsServiceRepository
    {
        public void GetServiceData()
        {
            //TODO: Implement this
            throw new System.NotImplementedException();
        }
    }
}
