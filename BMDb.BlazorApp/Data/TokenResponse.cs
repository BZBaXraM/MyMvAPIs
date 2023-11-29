using System.Text.Json.Serialization;

namespace BMDb.BlazorApp.Data;

public class TokenResponse
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; } = default!;
}