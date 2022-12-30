using react_api;
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
    }
}