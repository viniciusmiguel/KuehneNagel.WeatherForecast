using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;
using System.IO;
using System.Xml.Serialization;
namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic
{
    /// <inheritdoc />
    public abstract class XmlRepositoryBase<T> : IXmlRepositoryBase<T> where T : class
    {
        /// <inheritdoc />
        public T Data { get; protected set; }
        /// <inheritdoc />
        public string RawData { protected get; set; }
        /// <inheritdoc />
        public virtual T Parse()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(RawData))
            {
                Data = (T) xmlSerializer.Deserialize(reader);
            }
            return Data;
        }
    }
}
