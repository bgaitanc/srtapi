using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.ToTable("Route");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(r => r.OriginDestinationId).IsRequired().HasColumnType("uuid");
        builder.Property(r => r.FinalDestinationId).IsRequired().HasColumnType("uuid");
        builder.Property(r => r.DistanceInKm).IsRequired().HasColumnType("numeric(10, 3)");
        builder.Property(r => r.EstimatedTime).IsRequired().HasColumnType("interval");
        builder.HasIndex(r => new { r.OriginDestinationId, r.FinalDestinationId }).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("CK_Route_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Route_OriginDestinationId_uuid", $"\"OriginDestinationId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Route_FinalDestinationId_uuid", $"\"FinalDestinationId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Route_DistanceInKm_numeric", "\"DistanceInKm\" > 0"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Route_EstimatedTime_interval", "\"EstimatedTime\" > interval '1 minute'"));
        builder.HasOne(r => r.OriginDestination).WithMany().HasForeignKey(x => x.OriginDestinationId);
        builder.HasOne(r => r.FinalDestination).WithMany().HasForeignKey(x => x.FinalDestinationId);
    }
}