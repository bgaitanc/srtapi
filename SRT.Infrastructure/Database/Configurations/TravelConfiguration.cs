using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class TravelConfiguration : IEntityTypeConfiguration<Travel>
{
    public void Configure(EntityTypeBuilder<Travel> builder)
    {
        builder.ToTable("Travel");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(t => t.RouteId).IsRequired().HasColumnType("uuid");
        builder.Property(t => t.VehicleId).IsRequired().HasColumnType("uuid");
        builder.Property(t => t.DriverId).IsRequired().HasColumnType("uuid");
        builder.Property(t => t.Price).IsRequired().HasColumnType("numeric(10, 2)");
        builder.Property(t => t.DepartureDate).IsRequired();
        builder.Property(t => t.ArrivalDate).IsRequired();
        builder.Property(t => t.Status)
            .HasDefaultValue(TravelStatus.Pending)
            .HasConversion(new EnumToStringConverter<TravelStatus>())
            .HasColumnType("travelstatus");
        //TODO agregar constraint para hacer viajes únicos
        builder.ToTable(t => t.HasCheckConstraint("CK_Travel_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Travel_RouteId_uuid", $"\"RouteId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Travel_VehicleId_uuid", $"\"VehicleId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Travel_DriverId_uuid", $"\"DriverId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Travel_Price_numeric", "\"Price\" > 0"));
        builder.ToTable(t =>
            t.HasCheckConstraint("CK_Travel_DepartureDate_timestamp", "\"DepartureDate\" > '2023-01-01'::date"));
        builder.ToTable(t =>
            t.HasCheckConstraint("CK_Travel_ArrivalDate_timestamp", "\"ArrivalDate\" > '2023-01-01'::date"));
        builder.HasOne(t => t.Route).WithMany().HasForeignKey(x => x.RouteId);
        builder.HasOne(t => t.Vehicle).WithMany().HasForeignKey(x => x.VehicleId);
        builder.HasOne(t => t.Driver).WithMany().HasForeignKey(x => x.DriverId);
    }
}