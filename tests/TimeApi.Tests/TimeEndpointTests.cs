using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TimeApi.Tests;

public class TimeEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TimeEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetTimeReturnsAValidUtcTimestamp()
    {
        var response = await _client.GetAsync("/time");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);

        using var payload = JsonDocument.Parse(await response.Content.ReadAsStreamAsync());
        var utcText = payload.RootElement.GetProperty("utc").GetString();

        Assert.NotNull(utcText);
        Assert.True(DateTimeOffset.TryParse(utcText, out var timestamp));
        Assert.Equal(TimeSpan.Zero, timestamp.Offset);
    }
}
