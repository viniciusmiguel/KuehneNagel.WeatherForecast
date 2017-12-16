namespace KuehneNagel.WeatherForecast.Domain.Interfaces.Repositories.Generic
{
    public interface IServiceRepositoryBase<T> where T : class
    {
        string Xml { get; set; }
        void GetServiceData();
    }
}
