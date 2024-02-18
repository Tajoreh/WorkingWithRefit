using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;

namespace SampleUsage;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("", async (string rawData) =>
        {
            var webAppApi = RestService.For<IWebAppApi>("https://google.com", new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
                UrlParameterFormatter = new DefaultUrlParameterFormatter()
            });

            var data = new DataDto()
            {
                Value = rawData
            };

            var content = await webAppApi.SendData(data);

            return Results.Ok(content);
        });

    }

}