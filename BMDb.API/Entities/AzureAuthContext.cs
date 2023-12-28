using BMDb.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Entities;

/// <summary>
/// AzureAuthContext class.
/// </summary>
public class AzureAuthContext : IdentityDbContext<AppUser>
{
    /// <summary>
    /// AzureAuthContext constructor.
    /// </summary>
    /// <param name="options"></param>
    public AzureAuthContext(DbContextOptions<AzureAuthContext> options) : base(options)
    {
    }

    /// <summary>
    /// Users DbSet
    /// </summary>
    public override DbSet<AppUser> Users => Set<AppUser>();
}