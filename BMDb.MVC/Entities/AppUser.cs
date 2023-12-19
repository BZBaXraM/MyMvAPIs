using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BMDb.MVC.Data;

public class AppUser : IdentityUser
{
    [Required]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}