using Refit;
using Shared;

namespace SimpleUsage;


public interface IWebAppApi
{
    [Get("/WeatherForecast")]
    Task<List<WeatherForecast>> GetWeatherForecast();
}