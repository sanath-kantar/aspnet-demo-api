using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PingPongApi.Tests;

public class PingEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public PingEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetPing_ReturnsOkWithStatusOkBody()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/ping");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Equal("{\"status\":\"ok\"}", body);
    }
}
