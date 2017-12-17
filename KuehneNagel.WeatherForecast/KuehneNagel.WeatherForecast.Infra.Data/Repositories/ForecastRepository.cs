using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.DbContexts;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;
using System;
using System.Linq;
namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    /// <inheritdoc />
    public class ForecastRepository : RepositoryBase<Forecast, int>, IForecastRepository
    {
        public ForecastRepository(EfContext databaseContext) : base(databaseContext)
        {
        }
        /// <inheritdoc />
        public void AddOrUpdate(Forecast forecast)
        {
            var select = from s in DbSet where s.Date == forecast.Date select s.Id;
            if (select.Count() > 0)
            {
                forecast.Id = select.FirstOrDefault();
                Update(forecast);
            }
            else
            {
                Create(forecast);
            }
        }
        /// <inheritdoc />
        public Forecast GetTodayForecast()
        {
            return (from fore in DbSet
                    where fore.Date.Day == DateTime.Now.Day && 
                          fore.Date.Month == DateTime.Now.Month &&
                          fore.Date.Year == DateTime.Now.Year 
                    select fore).FirstOrDefault();
        }
    }
}
