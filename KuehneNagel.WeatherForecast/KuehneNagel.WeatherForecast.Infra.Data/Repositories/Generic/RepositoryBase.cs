using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;
using KuehneNagel.WeatherForecast.Infra.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic
{
    /// <inheritdoc />
    public abstract class RepositoryBase<T, I> : IRepositoryBase<T, I> where T : class
    {
        protected readonly EfContext DatabaseContext;
        protected readonly DbSet<T> DbSet;
        public RepositoryBase(EfContext databaseContext)
        {
            DatabaseContext = databaseContext;
            DbSet = DatabaseContext.Set<T>();
        }
        /// <inheritdoc />
        public void Create(T data)
        {
            DbSet.Add(data);
            DatabaseContext.SaveChanges();  
        }
        /// <inheritdoc />
        public void Delete(I index)
        {
            DbSet.Remove(DbSet.Find(index));
            DatabaseContext.SaveChanges();
        }
        /// <inheritdoc />
        public T Read(I index)
        {
            return DbSet.Find(index);
        }
        /// <inheritdoc />
        public IEnumerable<T> ReadAll()
        {
            return DbSet;
        }
        /// <inheritdoc />
        public void Update(T data)
        {
            DbSet.Update(data);
            DatabaseContext.SaveChanges();
        }
    }
}
