using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BMDbMvcUI.Data;

public class AppUser : IdentityUser
{
    [Required]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}