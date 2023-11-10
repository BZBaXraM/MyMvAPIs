using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BMDb.API.Services;

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