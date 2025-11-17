using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rol", "Identity");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(r => r.Name).IsRequired().HasColumnType("varchar(50)");
        builder.HasIndex(r => r.Name).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("CK_Rol_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Rol_Name", "TRIM(\"Name\") <> ''"));
    }
}