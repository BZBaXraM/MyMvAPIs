namespace BMDb.BlazorApp.Services;

public interface IAsyncJwtService
{
    Task<string> GetAccessTokenAsync();
}