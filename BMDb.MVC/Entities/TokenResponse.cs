using System.Text.Json.Serialization;

namespace BMDb.MVC.Data;

public class TokenResponse
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; } = default!;
}