using SRT.Domain.Models.Dtos.Travels;

namespace SRT.Domain.Models.Dtos.DriverTrips;

public class AssignedTripResponse
{
    public Guid TravelId { get; set; }
    public RouteInfo Route { get; set; } = new();
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public VehicleInfo Vehicle { get; set; } = new();
    public int PassengerCount { get; set; }
    public string Status { get; set; } = string.Empty;
}

