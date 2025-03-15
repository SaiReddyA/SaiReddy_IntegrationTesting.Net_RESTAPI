using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using SaiReddy_IntegrationRestAPI;

public class WeatherControllerTests : IClassFixture<WebApplicationFactory<SaiReddy_IntegrationRestAPI.Program>>
{
    private readonly HttpClient _client;

    public WeatherControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetWeather_ShouldReturnSuccessAndData()
    {
        // Act
        var response = await _client.GetAsync("/Weather");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<dynamic>();
        Assert.NotNull(result);
        Assert.Equal(30, (int)result.Temperature);
        Assert.Equal("Sunny", (string)result.Condition);
    }
}
