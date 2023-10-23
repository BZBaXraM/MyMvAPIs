using Microsoft.AspNetCore.Identity;

namespace BMDbAPI.Services;

/// <summary>
/// Interface for token service.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// CreateToken method.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="roles"></param>
    /// <returns></returns>
    string CreateToken(IdentityUser user, IEnumerable<string> roles);
}