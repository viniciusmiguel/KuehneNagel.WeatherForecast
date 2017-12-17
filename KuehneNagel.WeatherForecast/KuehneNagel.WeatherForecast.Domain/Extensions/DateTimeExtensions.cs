using System;

namespace KuehneNagel.WeatherForecast.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FromUnixTimeStamp(this DateTime dateTime,double timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp);
        }
    }
}
