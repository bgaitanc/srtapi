using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "Identity");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(u => u.Name).IsRequired().HasColumnType("varchar(100)");
        builder.Property(u => u.Surname).IsRequired().HasColumnType("varchar(100)");
        builder.Property(u => u.Username).IsRequired().HasColumnType("varchar(50)");
        builder.Property(u => u.Password).IsRequired().HasColumnType("varchar(255)");
        builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(50)");
        builder.Property(u => u.PhoneNumber).IsRequired(false).HasColumnType("varchar(25)");
        builder.HasIndex(u => u.Username).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("CK_User_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_User_Name", "TRIM(\"Name\") <> ''"));
        builder.ToTable(t => t.HasCheckConstraint("CK_User_Surname", "TRIM(\"Surname\") <> ''"));
        builder.ToTable(t => t.HasCheckConstraint("CK_User_Username", "TRIM(\"Username\") <> ''"));
        builder.ToTable(t => t.HasCheckConstraint("CK_User_Password", "TRIM(\"Password\") <> ''"));
        builder.ToTable(t => t.HasCheckConstraint("CK_User_Email", "TRIM(\"Email\") <> ''"));
    }
}