using Refit;
using Shared;
using UsingAuthorizations;

string urlBaseIdentity = "https://localhost:5000";

var tokenApi = RestService.For<ITokenApi>(Constants.TokenUrlBaseAPI);
var token =await tokenApi.GetToken();


var weather = RestService.For<IWebAppApi>(Constants.UrlBaseAPI, new RefitSettings()
{
    AuthorizationHeaderValueGetter = delegate { return Task.FromResult(token); }
});



var weatherForecasts = await weather.GetWeatherForecast2();

Console.WriteLine(weatherForecasts);