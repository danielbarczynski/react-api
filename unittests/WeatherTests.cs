using FluentAssertions;
using Moq;
using tests_di_mock;
using tests_di_mock.Controllers;
using System;

namespace unittests
{
    public class WeatherTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWithoutDependencyInjection()
        {
            var weather1 = new WeatherForecast();

            weather1.TemperatureC = 100;
            var weather2 = new BadController(weather1);
            var wget1 = weather1.GetTemperature();
            var wget2 = weather2.GetTemperature();
            wget1.Should().Be(wget2); // FAIL: they are not the same
        }

        [Test]
        public void TestWithDependencyInjection()
        {
            IWeatherForecast weather1 = new WeatherForecast();

            weather1.TemperatureC = 50;
            var weather2 = new WeatherForecastController(weather1);
            var wget1 = weather1.GetTemperature();
            var wget2 = weather2.GetTemperature();

            wget2.Should().Be(50);
            wget1.Should().Be(wget2); // SUCCESS: they are the same
        }

        [Test]
        public void TestWithMoq()
        {
            Mock<IWeatherForecast> weather1 = new();

            var wget1 = weather1.Setup(x => x.GetTemperature()).Returns(100);
            var weather2 = new WeatherForecastController(weather1.Object);
            var wget2 = weather2.GetTemperature();

            wget2.Should().Be(100); // SUCCESS: they are the same
        }
    }
}