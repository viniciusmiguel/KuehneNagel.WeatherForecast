using KuehneNagel.WeatherForecast.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KuehneNagel.WeatherForecast.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherForecastAppService WeatherForecastAppService;
        public HomeController(IWeatherForecastAppService appService)
        {
            WeatherForecastAppService = appService;
        }
        public IActionResult Index()
        {
            return View(WeatherForecastAppService.GetWeatherData());
        }
    }
}
