using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    public class ForecastsServiceRepository : XmlRepositoryBase<forecasts>, IForecastsServiceRepository
    {
        public void GetServiceData()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json",true)
            .Build();
            using (WebClient client = new WebClient())
            {          
                Xml = client.DownloadString(
                    config.GetConnectionString("ForecastService") != null ? 
                    config.GetConnectionString("ForecastService") 
                    : "http://www.ilmateenistus.ee/ilma_andmed/xml/forecast.php");
            }
        }

    }
}
