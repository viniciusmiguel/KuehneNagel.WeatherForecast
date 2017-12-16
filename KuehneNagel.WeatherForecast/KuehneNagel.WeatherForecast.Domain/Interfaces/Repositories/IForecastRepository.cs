using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    public interface IForecastRepository : IRepositoryBase<Forecast, int>
    {
        void AddOrUpdate(Forecast forecast);
        Forecast GetTodayForecast();
    }
}
