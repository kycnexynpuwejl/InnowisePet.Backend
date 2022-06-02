using InnowisePet.Identity.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnowisePet.Identity.Data;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData
        (
            new IdentityRole
            {
                Name = nameof(UserRole.Customer),
                NormalizedName = nameof(UserRole.Customer).ToUpper()
            },
            new IdentityRole
            {
                Name = nameof(UserRole.Administrator),
                NormalizedName = nameof(UserRole.Administrator).ToUpper()
            }
        );
    }
}