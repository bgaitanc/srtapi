namespace SRT.Domain.Models.Dtos.Reservations;

public class CreateReservationRequest
{
    public Guid TravelId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime ReservationDate { get; set; }
    public required List<short> Details { get; set; }
}