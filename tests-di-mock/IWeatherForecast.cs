namespace tests_di_mock
{
    public interface IWeatherForecast
    {
        DateOnly Date { get; set; }
        string? Summary { get; set; }
        int TemperatureC { get; set; }
        int TemperatureF { get; }
        int GetTemperature();
        IEnumerable<WeatherForecast> Get();
    }
}