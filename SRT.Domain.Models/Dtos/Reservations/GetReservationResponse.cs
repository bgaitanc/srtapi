namespace SRT.Domain.Models.Dtos.Reservations;

public class GetReservationResponse
{
    public Guid ReservationId { get; set; }
    public Guid TravelId { get; set; }
    public DateTime ReservationDate { get; set; }
    public List<short> Detail { get; set; } = [];
}