namespace BMDb.API.DTOs;

/// <summary>
/// DTO for registering a new user.
/// </summary>
public class RegisterRequestDto
{
    public string Username { get; set; }

    public string Password { get; set; }

    public string[] Roles { get; set; }
}