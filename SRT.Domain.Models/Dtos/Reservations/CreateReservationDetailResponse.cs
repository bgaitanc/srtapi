namespace SRT.Domain.Models.Dtos.Reservations;

public class CreateReservationDetailResponse : CreateReservationDetailRequest
{
    public Guid ReservationDetailId { get; set; }
}