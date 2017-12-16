using KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic;

namespace KuehneNagel.WeatherForecast.Infra.Data.Repositories.Generic
{
    public abstract class XmlRepositoryBase<T> : IXmlRepositoryBase<T> where T : class
    {
        public T Data { get; protected set; }

        public string Xml { get; set; }

        public virtual T Parse()
        {
            //TODO: implement this
            throw new System.NotImplementedException();
        }
    }
}
