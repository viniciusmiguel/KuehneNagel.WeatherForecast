using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories;
using KuehneNagel.WeatherForecast.Infra.Data.DbContexts;
using KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories
{
    /// <inheritdoc />
    public class ObservationRepository : RepositoryBase<Observation, int>, IObservationRepository
    {
        public ObservationRepository(EfContext databaseContext) : base(databaseContext)
        {
        }
        /// <inheritdoc />
        public void AddOrUpdate(Observation observation)
        {
            var select = from s in DbSet where s.Date == observation.Date select s.Id;
            if (select.Count() > 0)
            {
                observation.Id = select.FirstOrDefault();
                Update(observation);
            }
            else
            {
                Create(observation);
            }
        }
        /// <inheritdoc />
        public IEnumerable<Observation> GetAllObservationsFromToday()
        {
            return from s in DbSet
                   where s.Date.Day == DateTime.Now.Day &&
                   s.Date.Month == DateTime.Now.Month &&
                   s.Date.Year == DateTime.Now.Year
                   select s;
        }
    }
}
