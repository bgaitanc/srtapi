using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Travel : BaseEntity
{
    public required Guid RouteId { get; set; }
    public required Guid VehicleId { get; set; }
    public required Guid DriverId { get; set; }
    public required decimal Price { get; set; }
    public required DateTime DepartureDate { get; set; }
    public required DateTime ArrivalDate { get; set; }
    public TravelStatus Status { get; set; }
    public Route Route { get; set; }
    public Vehicle Vehicle { get; set; }
    public User Driver { get; set; }
}

public enum TravelStatus
{
    Completed,
    OnGoing,
    Pending
}