using Refit;
using System.Text.Json.Serialization;
using System.Text.Json;
using Client;

var webAppApi = RestService.For<IWebAppApi>("https://localhost:7292", new RefitSettings
{
    ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
    UrlParameterFormatter = new DefaultUrlParameterFormatter()
});

var dataToSend = new DataDto()
{
    Value = "Value",
};
var response = await webAppApi.SendData(dataToSend);

Console.WriteLine(response);