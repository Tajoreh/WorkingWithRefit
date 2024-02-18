using System.Text.Json.Serialization;
using Refit;
using Shared;
using SimpleUsage;

var weather = RestService.For<IWebAppApi>(Constants.UrlBaseAPI);

var weatherForecasts = await weather.GetWeatherForecast();

Console.WriteLine(weatherForecasts);