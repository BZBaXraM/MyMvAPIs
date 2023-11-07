namespace BMDb.API.DTOs;

/// <summary>
///    DTO for the LoginResponse
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    ///   The JWT token
    /// </summary>
    public string JwtToken { get; set; }
}