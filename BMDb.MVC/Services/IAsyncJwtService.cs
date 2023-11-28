namespace BMDb.MVC.Services;

public interface IAsyncJwtService
{
    Task<string> GetAccessTokenAsync();
}