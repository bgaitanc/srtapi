using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(c => c.Name).IsRequired().HasColumnType("varchar(50)");
        builder.HasIndex(c => c.Name).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("CK_Country_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Country_Name", "TRIM(\"Name\") <> ''"));
        builder.HasMany(x => x.States).WithOne(x => x.Country).HasForeignKey(x => x.CountryId);
    }
}