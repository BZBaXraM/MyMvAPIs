using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BMDb.API.Services;

/// <summary>
/// Interface for token service.
/// </summary>
public class TokenService : ITokenService
{
    private readonly IConfiguration _config;

    /// <summary>
    /// Constructor for injecting IConfiguration.
    /// </summary>
    /// <param name="config"></param>
    public TokenService(IConfiguration config)
        => _config = config;

    /// <summary>
    /// Creates a token for a user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="roles"></param>
    /// <returns></returns>
    public string CreateToken(IdentityUser user, IEnumerable<string> roles)
    {
        var claims = new List<Claim> { new(ClaimTypes.Email, user.Email) };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: signing
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}