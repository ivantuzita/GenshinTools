using GenshinTools.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinTools.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
            new ApplicationUser {
                Id = "e6b21612-edc8-4dcf-8161-3462e8dc0577",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApplicationUser {
                Id = "5e45fdf0-ba32-4314-9d0c-88cda09191ee",
                UserName = "user",
                NormalizedUserName = "USER",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }
        );
    }
}
