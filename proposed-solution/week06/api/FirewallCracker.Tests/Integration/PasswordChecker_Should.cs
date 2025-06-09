using System.Net.Http.Json;
using FirewallCracker.Commands;
using FirewallCracker.Core;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FirewallCracker.Tests.Integration;

public class PasswordCheckerShould(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private const string PasswordCheck = "/api/password-check";
    private const CheckPassword? NoCommand = null;

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Return_BadRequest_For_Null()
        => (await CheckPasswordFor(NoCommand))
            .FailedWithBadRequest();

    [Fact]
    public async Task Return_Ok_For_Failing_Password()
    {
        var response = await CheckPasswordFor(new CheckPassword("A1b#"));
        response.EnsureSuccessStatusCode();
        var result = (await response.Content.ReadFromJsonAsync<PasswordResult>())!;

        Assert.Equal(
            new PasswordResult(
                IsValid: false,
                Rules: new Rules(
                    MinLength: false,
                    HasUpperCase: true,
                    HasLowerCase: true,
                    HasNumber: true,
                    HasCyberSymbol: true,
                    HasOnlyAllowedCharacters: true
                ),
                Message: "Password must be at least 8 characters long"
            ),
            result);
    }

    private async Task<HttpResponseMessage> CheckPasswordFor(CheckPassword? command)
        => await _client.PostAsJsonAsync(PasswordCheck, command);
}