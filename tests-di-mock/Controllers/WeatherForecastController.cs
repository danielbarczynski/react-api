using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tests_di_mock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecast _weather;
        public WeatherForecastController(IWeatherForecast weather)
        {
            _weather = weather;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weather.Get();
        }

        public int GetTemperature()
        {
            return _weather.GetTemperature();
        }
    }
}