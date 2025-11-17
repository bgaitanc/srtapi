namespace SRT.Domain.Models.Dtos.Reservations;

public class CreateReservationDetailRequest
{
    public Guid ReservationId { get; set; }
    public short SeatNumber { get; set; }
}