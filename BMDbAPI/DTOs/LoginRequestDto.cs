namespace BMDbAPI.DTOs;

/// <summary>
/// DTO for logging in a user.
/// </summary>
public class LoginRequestDto
{
    public string Username { get; set; }

    public string Password { get; set; }
}