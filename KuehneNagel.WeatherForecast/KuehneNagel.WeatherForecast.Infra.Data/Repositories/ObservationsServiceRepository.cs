using KuehneNagel.WeatherForecast.Domain.Entities.Xml;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Linq;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    /// <inheritdoc />
    public class ObservationsServiceRepository : XmlRepositoryBase<observations>, IObservationsServiceRepository
    {
        /// <inheritdoc />
        public void GetServiceData()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();
            using (WebClient client = new WebClient())
            {
                RawData = client.DownloadString(
                    config.GetConnectionString("ObservationsService") != null ? 
                    config.GetConnectionString("ObservationsService") :
                    "http://www.ilmateenistus.ee/ilma_andmed/xml/observations.php");
            }
        }
        /// <inheritdoc />
        public observationsStation GetStationData(string placeName)
        {
            GetServiceData();
            
            return (from s in Parse().station
                    where s.name.Equals(placeName)
                    select s).FirstOrDefault();
        }
    }
}
