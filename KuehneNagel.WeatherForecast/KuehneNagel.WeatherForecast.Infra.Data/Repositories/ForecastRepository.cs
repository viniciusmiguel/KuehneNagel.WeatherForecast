using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.DbContexts;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;
using System;
using System.Linq;
namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    public class ForecastRepository : RepositoryBase<Forecast, int>, IForecastRepository
    {
        public ForecastRepository(EfContext databaseContext) : base(databaseContext)
        {
        }

        public void AddOrUpdate(Forecast forecast)
        {
            if(DbSet.Find(forecast.Id) !=null)
            {
                Update(forecast);
            }
            else
            {
                Create(forecast);
            }
        }

        public Forecast GetTodayForecast()
        {
            return (from fore in DbSet
                    where fore.Id.Day == DateTime.Now.Day && 
                          fore.Id.Month == DateTime.Now.Month &&
                          fore.Id.Year == DateTime.Now.Year 
                    select fore).FirstOrDefault();
        }
    }
}
