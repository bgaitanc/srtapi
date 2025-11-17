using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class UserRolConfiguration : IEntityTypeConfiguration<UserRol>
{
    public void Configure(EntityTypeBuilder<UserRol> builder)
    {
        builder.ToTable("UserRol", "Identity");
        builder.HasKey(ur => ur.Id);
        builder.Property(ur => ur.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(ur => ur.UserId).IsRequired().HasColumnType("uuid");
        builder.Property(ur => ur.RolId).IsRequired().HasColumnType("uuid");
        builder.HasIndex(x => new { x.UserId, x.RolId }).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("CK_UserRoles_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_UserRoles_UserId_uuid", $"\"UserId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_UserRoles_RolId_uuid", $"\"RolId\" <> '{Guid.Empty}'"));
        builder.HasOne(ur => ur.Rol);
        builder.HasOne(ur => ur.User);
    }
}