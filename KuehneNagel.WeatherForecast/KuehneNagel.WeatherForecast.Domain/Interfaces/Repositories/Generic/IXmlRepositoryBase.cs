
namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic
{
    /// <summary>
    /// Represents an abstraction to convert a string to an entity
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    public interface IXmlRepositoryBase<T> where T: class
    {
        /// <summary>
        /// The String data to be parsed
        /// </summary>
        string RawData { set; }
        /// <summary>
        /// The parsed data
        /// </summary>
        T Data { get; }
        /// <summary>
        /// Parse to the entity from a string
        /// </summary>
        /// <returns></returns>
        T Parse();
    }
}
