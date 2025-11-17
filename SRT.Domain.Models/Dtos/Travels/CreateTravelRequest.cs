namespace SRT.Domain.Models.Dtos.Travels;

public class CreateTravelRequest
{
    public Guid RouteId { get; set; }
    public Guid VehicleId { get; set; }
    public Guid DriverId { get; set; }
    public decimal Price { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
}