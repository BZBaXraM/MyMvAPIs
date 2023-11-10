using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Data;

/// <inheritdoc />
public class AuthDbContext : IdentityDbContext
{
    /// <inheritdoc />
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        const string readerRoleId = "8bb3e2a3-d7d6-4707-a54c-afc4898fb6a7";
        const string writerRoleId = "81031268-a1c4-4ab1-b940-9bf98c7ea07c";
        var roles = new List<IdentityRole>
        {
            new()
            {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "READER"
            },
            new()
            {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "WRITER"
            }
        };
        
        builder.Entity<IdentityRole>().HasData(roles);
    }
}