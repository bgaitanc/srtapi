using SRT.Domain.Entities.Base;
using SRT.Domain.Entities.Identity;

namespace SRT.Domain.Entities;

public class Reservation : BaseEntity
{
    public required Guid TravelId { get; set; }
    public required Guid ClientId { get; set; }
    public required DateTime ReservationDate { get; set; }
    public required ReservationStatus Status { get; set; }
    public Travel Travel { get; set; }
    public User Client { get; set; }
    public ICollection<ReservationDetail> ReservationDetails { get; set; }
}

public enum ReservationStatus
{
    Pending,
    Completed,
    Canceled
}