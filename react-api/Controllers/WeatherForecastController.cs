using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace react_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecast _weather;
        public WeatherForecastController(IWeatherForecast weather)
        {
            _weather = weather; // new object, no dependencies
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