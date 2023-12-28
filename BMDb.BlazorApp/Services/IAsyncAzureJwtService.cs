namespace BMDb.BlazorApp.Services;

public interface IAsyncAzureJwtService
{
    Task<string> GetAccessTokenAsync();
}