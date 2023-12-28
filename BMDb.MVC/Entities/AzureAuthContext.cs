using BMDb.MVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMDb.MVC.Entities;

public class AzureAuthContext : IdentityDbContext<IdentityUser>
{
    public AzureAuthContext(DbContextOptions<AzureAuthContext> options) : base(options)
    {
    }
    
    public new IEnumerable<AppUser> Users => Set<AppUser>();
}