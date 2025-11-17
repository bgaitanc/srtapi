namespace SRT.Domain.Models.Dtos.Reservations;

public class GetReservationQueryResponse
{
    public Guid ReservationId { get; set; }
    public Guid TravelId { get; set; }
    public DateTime ReservationDate { get; set; }
    public short SeatNumber { get; set; }
}