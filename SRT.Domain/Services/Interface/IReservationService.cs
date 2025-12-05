using SRT.Domain.Models.Dtos.Reservations;

namespace SRT.Domain.Services.Interface;

public interface IReservationService
{
    Task<GetReservationInfoResponse> CreateReservation(CreateReservationRequest request);
    Task<IEnumerable<GetReservationInfoResponse>> GetReservationDetailsByUserId(Guid userId);
    Task<ReservationValidationResult> ValidateReservationAsync(ValidateReservationRequest request);
}