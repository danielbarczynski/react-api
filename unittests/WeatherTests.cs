using FluentAssertions;
using Moq;
using react_api;
using react_api.Controllers;
using System;

namespace unittests
{
    public class WeatherTests
    {

        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void TestWithoutDependencyInjection()
        //{
        //    var weather1 = new WeatherForecast();
        //    var weather2 = new WeatherForecastController();
        //    var wget1 = weather1.Get();
        //    var wget2 = weather2.Get();
        //    wget1.Should().BeSameAs(wget2); // FAIL: values differ at index [0]
        //}

        [Test]
        public void TestWithDependencyInjection()
        {
            IWeatherForecast weather1 = new WeatherForecast();

            weather1.TemperatureC = 50;
            var weather2 = new WeatherForecastController(weather1);
            var wget1 = weather1.GetTemperature();
            var wget2 = weather2.GetTemperature();

            wget2.Should().Be(50);
            wget1.Should().Be(wget2); // SUCCESS: THEY ARE THE SAME
        }

        [Test]
        public void TestWithMoq()
        {
            Mock<IWeatherForecast> weather1 = new();

            var wget1 = weather1.Setup(x => x.GetTemperature()).Returns(100);
            var weather2 = new WeatherForecastController(weather1.Object);
            var wget2 = weather2.GetTemperature();

            wget2.Should().Be(100);
        }
    }
}