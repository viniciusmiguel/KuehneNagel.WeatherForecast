using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.DbContexts;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    public class ObservationRepository : RepositoryBase<Observation, int>, IObservationRepository
    {
        public ObservationRepository(EfContext databaseContext) : base(databaseContext)
        {
        }
    }
}
