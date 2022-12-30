using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tests_di_mock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BadController : ControllerBase
    {
        private readonly WeatherForecast _weather;
        public BadController(WeatherForecast weather)
        {
            //_weather = weather; // dependency incjection
            _weather = new WeatherForecast(); // no dependency injection
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