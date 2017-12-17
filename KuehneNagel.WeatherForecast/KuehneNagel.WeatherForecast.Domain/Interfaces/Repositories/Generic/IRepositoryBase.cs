using System.Collections.Generic;

namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic
{
    /// <summary>
    /// Represents a basic CRUD operations for data access
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    /// <typeparam name="I">The index type</typeparam>
    public interface IRepositoryBase<T,I> where T : class
    {
        /// <summary>
        /// Create a new row
        /// </summary>
        /// <param name="data">Data to be stored</param>
        void Create(T data);
        /// <summary>
        /// Read a row of data
        /// </summary>
        /// <param name="index">the index number to be read</param>
        /// <returns></returns>
        T Read(I index);
        /// <summary>
        /// Read all data
        /// </summary>
        /// <returns>A list of rows</returns>
        IEnumerable<T> ReadAll();
        /// <summary>
        /// Update a data row
        /// </summary>
        /// <param name="data">The data to be updated</param>
        void Update(T data);
        /// <summary>
        /// Delete a row
        /// </summary>
        /// <param name="index">The row index number to be deleted</param>
        void Delete(I index);
    }
}
