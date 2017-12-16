using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;
using KuehneNagel.WeatherForecast.Infra.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic
{
    public abstract class RepositoryBase<T, I> : IRepositoryBase<T, I> where T : class
    {
        protected readonly EfContext DatabaseContext;
        protected readonly DbSet<T> DbSet;
        public RepositoryBase(EfContext databaseContext)
        {
            DatabaseContext = databaseContext;
            DbSet = DatabaseContext.Set<T>();
        }
        public void Create(T data)
        {
            DbSet.Add(data);
            DatabaseContext.SaveChangesAsync();
        }

        public void Delete(I index)
        {
            DbSet.Remove(DbSet.Find(index));
            DatabaseContext.SaveChangesAsync();
        }

        public T Read(I index)
        {
            return DbSet.Find(index);
        }

        public IEnumerable<T> ReadAll()
        {
            return DbSet;
        }

        public void Update(T data)
        {
            DbSet.Update(data);
            DatabaseContext.SaveChangesAsync();
        }
    }
}
