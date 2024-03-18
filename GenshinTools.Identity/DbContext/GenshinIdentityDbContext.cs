using GenshinTools.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GenshinTools.Identity.DbContext;

public class GenshinIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public GenshinIdentityDbContext(DbContextOptions<GenshinIdentityDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(GenshinIdentityDbContext).Assembly);
    }
}
