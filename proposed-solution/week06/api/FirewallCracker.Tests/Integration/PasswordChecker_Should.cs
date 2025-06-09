using Microsoft.AspNetCore.Mvc.Testing;

namespace FirewallCracker.Tests.Integration;

public class PasswordCheckerShould(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Return_Error500_For_Unknown_Command()
    {
        var response = await _client.PostAsync("/api/password-check", null);
        response.FailedWithInternalError();
    }
}