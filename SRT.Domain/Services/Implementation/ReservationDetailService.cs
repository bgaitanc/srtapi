using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservations;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class ReservationDetailService(IReservationDetailRepository reservationDetailRepository)
    : IReservationDetailService
{
    public async Task<GetReservationDetailResponse> GetReservationDetailByTravelId(Guid travelId)
    {
        return await reservationDetailRepository.GetReservationDetailByTravelId(travelId);
    }

    public async Task<CreateReservationDetailResponse> CreateReservationDetail(CreateReservationDetailRequest request)
    {
        var newDetail = new ReservationDetail
        {
            SeatNumber = request.SeatNumber,
            ReservationId = request.ReservationId
        };

        var result = await reservationDetailRepository.CreateAsync(newDetail);
        return new CreateReservationDetailResponse
        {
            ReservationDetailId = result.Id,
            ReservationId = request.ReservationId,
            SeatNumber = request.SeatNumber
        };
    }
}