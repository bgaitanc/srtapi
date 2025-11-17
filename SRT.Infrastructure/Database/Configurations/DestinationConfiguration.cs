using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.ToTable("Destination");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(d => d.Name).IsRequired().HasColumnType("varchar(50)");
        builder.Property(d => d.StateId).IsRequired().HasColumnType("uuid");
        builder.HasIndex(d => new { d.StateId, d.Name }).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("CK_Destination_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Destination_StateId_uuid", $"\"StateId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Destination_Name", "TRIM(\"Name\") <> ''"));
        builder.HasOne(d => d.State).WithMany(s => s.Destinations).HasForeignKey(d => d.StateId);
    }
}