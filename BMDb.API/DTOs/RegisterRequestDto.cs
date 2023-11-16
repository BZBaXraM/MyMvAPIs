namespace BMDb.API.DTOs;

/// <summary>
/// DTO for registering a new user.
/// </summary>
public class RegisterRequestDto
{
    /// <summary>
    /// This property is used to define the Username property.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// This property is used to define the Password property.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}