using SRT.Domain.Models.Dtos.Travels;

namespace SRT.Domain.Models.Dtos.Reservations;

public class GetReservationInfoResponse
{
    public Guid ReservationId { get; set; }
    public Guid TravelId { get; set; }
    public DateTime ReservationDate { get; set; }
    public IEnumerable<CreateReservationDetailResponse> Details { get; set; } = [];
    //TODO cambiar a GetTravelResponse
    public GetTravelInfoResponse Travel { get; set; }
    public RouteInfo Route { get; set; }
    public decimal Total { get; set; }
}