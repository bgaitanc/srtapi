using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservation");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(r => r.TravelId).IsRequired().HasColumnType("uuid");
        builder.Property(r => r.ClientId).IsRequired().HasColumnType("uuid");
        builder.Property(r => r.ReservationDate).IsRequired();
        builder.Property(r => r.Status)
            .HasDefaultValue(ReservationStatus.Pending)
            .HasConversion(new EnumToStringConverter<ReservationStatus>())
            .HasColumnType("reservationstatus");
        builder.ToTable(t => t.HasCheckConstraint("CK_Reservation_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Reservation_TravelId_uuid", $"\"TravelId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Reservation_ClientId_uuid", $"\"ClientId\" <> '{Guid.Empty}'"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Reservation_ReservationDate_timestamp",
            "\"ReservationDate\" <> '2023-01-01'::date"));
        builder.HasOne(r => r.Travel).WithMany().HasForeignKey(x => x.TravelId);
        builder.HasOne(r => r.Client).WithMany().HasForeignKey(x => x.ClientId);
        builder.HasMany(r => r.ReservationDetails).WithOne(r => r.Reservation).HasForeignKey(r => r.ReservationId);
    }
}