namespace SRT.Domain.Models.Dtos.Reservations;

public class GetReservationDetailResponse
{
    public Guid TravelId { get; set; }
    public short Capacity { get; set; }
    public IEnumerable<short> ReservedSeats { get; set; } = [];
}