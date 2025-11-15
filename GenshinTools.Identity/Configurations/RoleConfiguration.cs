using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenshinTools.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole> {
    public void Configure(EntityTypeBuilder<IdentityRole> builder) {
        builder.HasData(
            new IdentityRole {
                Id = "ba8559f7-fcac-40e7-8afa-47a9b4cd8be8",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole {
                Id = "a13a8686-8983-46a4-b711-35cef863e2a0",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
    }
}
