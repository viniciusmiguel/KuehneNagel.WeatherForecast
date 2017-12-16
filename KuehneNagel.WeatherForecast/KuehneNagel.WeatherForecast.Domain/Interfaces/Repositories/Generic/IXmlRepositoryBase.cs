
namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic
{
    public interface IXmlRepositoryBase<T> where T: class
    {
        string Xml { get; }
        T Data { get; }
        T Parse();
    }
}
