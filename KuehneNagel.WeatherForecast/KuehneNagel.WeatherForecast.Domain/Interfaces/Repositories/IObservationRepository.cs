using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;
using KuehneNagel.WeatherForecast.Domain.Entities;
namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    public interface IObservationRepository : IRepositoryBase<Observation, int>      
    {
        void AddOrUpdate(Observation observation);
    }
}
