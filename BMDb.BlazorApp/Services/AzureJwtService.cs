using System.Text;
using System.Text.Json;
using BMDb.BlazorApp.Data;

namespace BMDb.BlazorApp.Services;

public class AzureJwtService : IAsyncAzureJwtService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AzureJwtService(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;


    public async Task<string> GetAccessTokenAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var message = await client.PostAsync("https://bmdb.azurewebsites.net/api/auth/login",
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