namespace SRT.Domain.Models.Dtos.Travels;

public class GetTravelRequest
{
    public Guid? TravelId { get; set; }
    public Guid? RouteId { get; set; }
    public Guid? VehicleId { get; set; }
    public Guid? DriverId { get; set; }
}