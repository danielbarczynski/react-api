using react_api;
using react_api.Controllers;
using System;

namespace unittests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWithoutServiceAndIntreface()
        {
            var weather = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Today),
                TemperatureC = 30,
                Summary = "Sweltering"
            };
            Assert.AreEqual(30, weather.TemperatureC);
        }

        [Test]
        public void TestWithService()
        {
            var weather1 = new WeatherService();
            var weather2 = new WeatherForecastController();
            var wget1 = weather1.Get();
            var wget2 = weather2.Get();
            Assert.AreEqual(wget2, wget1); // FAIL: values differ at index [0]
        }
    }
}