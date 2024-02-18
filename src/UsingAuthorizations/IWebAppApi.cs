using Refit;
using Shared;

namespace UsingAuthorizations;

public interface ITokenApi
{
    [Get("/getToken")]
    Task<string> GetToken();
}

public interface IWebAppApi
{
    [Get("/WeatherForecast")]
    [Headers("Authorization: Bearer")]
    Task<List<WeatherForecast>> GetWeatherForecast2();
}