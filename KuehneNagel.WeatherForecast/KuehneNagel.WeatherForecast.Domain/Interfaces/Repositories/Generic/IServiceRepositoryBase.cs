namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic
{
    /// <summary>
    /// Represents a Service Repository
    /// </summary>
    /// <typeparam name="T">The entity type of the service</typeparam>
    public interface IServiceRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Retrieves the data from service
        /// </summary>
        void GetServiceData();
    }
}
