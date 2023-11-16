namespace BMDb.API.DTOs;

/// <summary>
/// DTO for logging in a user.
/// </summary>
public class LoginRequestDto
{
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = string.Empty;
}