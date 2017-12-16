using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic
{
    public interface IRepositoryBase<T,I> where T : class
    {
        void Create(T data);

        T Read(I index);

        IEnumerable<T> ReadAll();

        void Update(T data);

        void Delete(I index);
    }
}
