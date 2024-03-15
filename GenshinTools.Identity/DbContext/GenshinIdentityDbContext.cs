using GenshinTools.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
