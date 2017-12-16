using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;
using System.IO;
using System.Xml.Serialization;
namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic
{
    public abstract class XmlRepositoryBase<T> : IXmlRepositoryBase<T> where T : class
    {
        public T Data { get; protected set; }

        public string Xml { get; set; }

        public virtual T Parse()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(Xml))
            {
                Data = (T) xmlSerializer.Deserialize(reader);
            }
            return Data;
        }
    }
}
