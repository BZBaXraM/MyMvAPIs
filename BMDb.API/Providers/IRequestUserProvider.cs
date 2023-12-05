namespace BMDb.API.Providers;

/// <summary>
///    This interface is used to get the user information from the request.
/// </summary>
public interface IRequestUserProvider
{
    /// <summary>
    ///   Gets the user information from the request.
    /// </summary>
    /// <returns></returns>
    UserInfo? GetUserInfo();
}