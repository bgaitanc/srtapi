using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicle");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(v => v.RegistrationPlate).IsRequired().HasColumnType("varchar(10)");
        builder.Property(v => v.Model).IsRequired().HasColumnType("varchar(50)");
        builder.Property(v => v.Capacity).IsRequired().HasColumnType("smallint");
        builder.HasIndex(v => v.RegistrationPlate).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("CK_Vehicle_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Vehicle_RegistrationPlate_varchar", "TRIM(\"RegistrationPlate\") <> ''"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Vehicle_Model_varchar", "TRIM(\"Model\") <> ''"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Vehicle_Capacity_smallint", "\"Capacity\" BETWEEN 1 AND 1000"));
    }
}