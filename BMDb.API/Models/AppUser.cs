using Microsoft.AspNetCore.Identity;

namespace BMDb.API.Models;

/// <summary>
/// This class is used to define the AppUser class.
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// This property is used to define the RefreshToken property.
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Movie collection.
    /// </summary>
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}