using Refit;

namespace SampleUsage;


public interface IWebAppApi
{
    [Post("/getWeatherForecast")]
    Task<List<WeatherForecast>> getData(int index);
}