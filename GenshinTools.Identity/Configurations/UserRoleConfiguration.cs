using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinTools.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "ba8559f7-fcac-40e7-8afa-47a9b4cd8be8",
                UserId = "5e45fdf0-ba32-4314-9d0c-88cda09191ee"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a13a8686-8983-46a4-b711-35cef863e2a0",
                UserId = "e6b21612-edc8-4dcf-8161-3462e8dc0577"
            }
        );
    }
}
