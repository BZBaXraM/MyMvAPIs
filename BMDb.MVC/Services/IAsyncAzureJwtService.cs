namespace BMDb.MVC.Services;

public interface IAsyncAzureJwtService
{
    Task<string> GetAccessTokenAsync();
}