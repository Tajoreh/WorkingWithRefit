using Refit;
namespace Client;

public class DataDto
{
    public string Value { get; set; }
}

public interface IWebAppApi
{
    [Post("/verify")]
    Task<string> SendData([AliasAs("data")] DataDto data);
}