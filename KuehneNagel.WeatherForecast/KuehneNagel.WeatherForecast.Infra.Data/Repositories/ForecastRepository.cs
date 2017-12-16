using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.DbContexts;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    public class ForecastRepository : RepositoryBase<Forecast, int>, IForecastRepository
    {
        public ForecastRepository(EfContext databaseContext) : base(databaseContext)
        {
        }
    }
}
