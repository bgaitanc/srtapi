namespace SRT.Domain.Models.Dtos.Reservations;

public class ValidateReservationRequest
{
    public Guid ReservationId { get; set; }
}

public class ValidateReservationResponse
{
    public bool IsValid { get; set; }
    public Guid ReservationId { get; set; }
    public string PassengerName { get; set; } = string.Empty;
    public string PassengerSurname { get; set; } = string.Empty;
    public List<short> SeatNumbers { get; set; } = new();
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime DepartureDate { get; set; }
}

