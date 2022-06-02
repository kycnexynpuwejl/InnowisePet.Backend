using InnowisePet.Identity.Models;
using InnowisePet.Identity.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnowisePet.Identity.Data;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasData
        (
            new IdentityRole
            {
                Name = nameof(UserRole.Manager),
                NormalizedName = nameof(UserRole.Manager).ToUpper()
            },
            new IdentityRole
            {
                Name = nameof(UserRole.Administrator),
                NormalizedName = nameof(UserRole.Administrator).ToUpper()
            }
        );
    }
}