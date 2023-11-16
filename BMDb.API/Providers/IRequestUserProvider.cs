namespace BMDb.API.Providers;

public interface IRequestUserProvider
{
    UserInfo? GetUserInfo();
}