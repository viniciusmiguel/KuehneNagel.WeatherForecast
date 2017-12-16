using KuehneNagel.WeatherForecast.Domain.Entities;
using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories
{
    public interface IForecastRepository : IRepositoryBase<Forecast, int>
    {
    }
}
