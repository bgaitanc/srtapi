using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class ReservationDetail : BaseEntity
{
    public Guid ReservationId { get; set; }
    public short SeatNumber { get; set; }
    public Reservation Reservation { get; set; }
}