using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservations;
using SRT.Domain.Models.Dtos.Travels;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class ReservationService(
    IReservationRepository reservationRepository,
    ITravelRepository travelRepository)
    : IReservationService
{
    public async Task<GetReservationInfoResponse> CreateReservation(CreateReservationRequest request)
    {
        var newReservation = new Reservation
        {
            TravelId = request.TravelId,
            ClientId = request.ClientId,
            ReservationDate = request.ReservationDate,
            Status = ReservationStatus.Pending,
            ReservationDetails = request.Details.Select(d => new ReservationDetail
            {
                SeatNumber = d
            }).ToList()
        };

        var result = await reservationRepository.CreateAsync(newReservation);

        var travel = await travelRepository.GetTravelById(request.TravelId);

        return new GetReservationInfoResponse
        {
            ReservationId = result.Id,
            TravelId = request.TravelId,
            ReservationDate = request.ReservationDate,
            Details = result.ReservationDetails.Select(d => new CreateReservationDetailResponse
            {
                ReservationDetailId = d.Id,
                SeatNumber = d.SeatNumber,
                ReservationId = d.ReservationId
            }),
            Travel = new GetTravelInfoResponse
            {
                Price = travel!.Price,
                ArrivalDate = travel.ArrivalDate,
                DepartureDate = travel.DepartureDate
            },
            Route = travel.Route,
            Total = travel.Price * request.Details.Count
        };
    }

    public async Task<IEnumerable<GetReservationInfoResponse>> GetReservationDetailsByUserId(Guid userId)
    {
        var reservations = await reservationRepository.GetReservationsByUserId(userId);
        var listData = reservations.ToList();
        if (listData.Count == 0) return new List<GetReservationInfoResponse>();

        var travels = await travelRepository.GetTravels();

        return listData.Select(x =>
        {
            var travel = travels.First(v => v.TravelId == x.TravelId);

            return new GetReservationInfoResponse
            {
                ReservationId = x.ReservationId,
                TravelId = x.TravelId,
                ReservationDate = x.ReservationDate,
                Details = x.Detail.Select(z => new CreateReservationDetailResponse
                {
                    SeatNumber = z
                }),
                Travel = new GetTravelInfoResponse
                {
                    Price = travel.Price,
                    ArrivalDate = travel.ArrivalDate,
                    DepartureDate = travel.DepartureDate
                },
                Route = travel.Route,
                Total = travel.Price * x.Detail.Count
            };
        });
    }
}