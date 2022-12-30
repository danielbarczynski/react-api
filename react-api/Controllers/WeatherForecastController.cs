using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace react_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherService _service;
        public WeatherForecastController()
        {
            _service = new WeatherService(); // new object, no dependencies
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _service.Get();
        }
    }
}