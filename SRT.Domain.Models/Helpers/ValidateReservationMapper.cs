using SRT.Domain.Models.Dtos.Reservations;

namespace SRT.Domain.Models.Helpers
{
    public static class ValidateReservationMapper
    {
        public static ValidateReservationResponse ToResponse(this ReservationValidationResult result)
        {
            return result.IsValid
                ? new ValidateReservationResponse
                {
                    IsValid = true,
                    ReservationId = result.ReservationId,
                    PassengerName = result.PassengerName,
                    PassengerSurname = result.PassengerSurname,
                    SeatNumbers = result.SeatNumbers,
                    Origin = result.Origin,
                    Destination = result.Destination,
                    DepartureDate = result.DepartureDate
                }
                : new ValidateReservationResponse
                {
                    IsValid = false,
                    ReservationId = result.ReservationId,
                    PassengerName = string.Empty,
                    PassengerSurname = string.Empty,
                    SeatNumbers = new List<short>(),
                    Origin = string.Empty,
                    Destination = string.Empty,
                    DepartureDate = DateTime.MinValue
                };
        }
    }
}

