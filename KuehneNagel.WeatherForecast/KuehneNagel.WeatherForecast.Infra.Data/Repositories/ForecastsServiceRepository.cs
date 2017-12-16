using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    public class ForecastsServiceRepository : XmlRepositoryBase<forecasts>, IForecastsServiceRepository
    {

        public void GetServiceData()
        {
            //TODO: implement this
            throw new System.NotImplementedException();
        }

    }
}
