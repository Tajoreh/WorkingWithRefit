using Microsoft.AspNetCore.Authorization;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/getToken", () =>
{
    var token = Guid.NewGuid().ToString();

    return token;
});


app.MapGet("/WeatherForecast", [Authorize] () =>
{
    var forecast = Enumerable.Range(1, 5).Select(i =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});


app.Run();

