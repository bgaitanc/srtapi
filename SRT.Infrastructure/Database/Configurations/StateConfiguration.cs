using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("State");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(s => s.Name).IsRequired().HasColumnType("varchar(50)");
        builder.Property(s => s.CountryId).IsRequired().HasColumnType("uuid");
        builder.HasIndex(s => new { s.CountryId, s.Name }).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("CK_State_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_State_CountryId_uuid", $"\"CountryId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_State_Name", "TRIM(\"Name\") <> ''"));
        builder.HasOne(s => s.Country);
    }
}