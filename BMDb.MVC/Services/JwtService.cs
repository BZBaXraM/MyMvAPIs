using System.Text;
using System.Text.Json;
using BMDb.MVC.Data;

namespace BMDb.MVC.Services;

public class JwtService : IAsyncJwtService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public JwtService(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;


    public async Task<string> GetAccessTokenAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var message = await client.PostAsync("https://localhost:7212/api/auth/login",
            new StringContent(JsonSerializer.Serialize(new
            {
                Email = "baxram1997007@gmail.com",
                Password = "Root@1997!"
            }), Encoding.UTF8, "application/json"));

        message.EnsureSuccessStatusCode();

        var jsonResponse = await message.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);

        return tokenResponse?.AccessToken!;
    }
}