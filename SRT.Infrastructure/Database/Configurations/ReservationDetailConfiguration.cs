using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRT.Domain.Entities;

namespace SRT.Infrastructure.Database.Configurations;

public class ReservationDetailConfiguration : IEntityTypeConfiguration<ReservationDetail>
{
    public void Configure(EntityTypeBuilder<ReservationDetail> builder)
    {
        builder.ToTable("ReservationDetail");
        builder.HasKey(rd => rd.Id);
        builder.Property(rd => rd.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(rd => rd.ReservationId).IsRequired().HasColumnType("uuid");
        builder.Property(rd => rd.SeatNumber).IsRequired().HasColumnType("smallint");
        builder.ToTable(t => t.HasCheckConstraint("CK_ReservationDetail_Id_uuid", $"\"Id\" <> '{Guid.Empty}'"));
        builder.ToTable(t =>
            t.HasCheckConstraint("CK_ReservationDetail_ReservationId_uuid", $"\"ReservationId\" <> '{Guid.Empty}'"));
        builder.ToTable(t =>
            t.HasCheckConstraint("CK_ReservationDetail_SeatNumber_uuid", $"\"SeatNumber\" BETWEEN 1 AND 1000"));
        builder.HasOne(rd => rd.Reservation).WithMany(r => r.ReservationDetails).HasForeignKey(r => r.ReservationId);
    }
}