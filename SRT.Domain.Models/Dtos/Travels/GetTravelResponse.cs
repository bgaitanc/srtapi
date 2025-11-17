using SRT.Domain.Entities;

namespace SRT.Domain.Models.Dtos.Travels;

public class GetTravelResponse : GetTravelRequest
{
    public decimal Price { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }

    public TravelStatus Status { get; set; }

    //Navigations
    public RouteInfo Route { get; set; }
    public VehicleInfo Vehicle { get; set; }
    public DriverInfo Driver { get; set; }
}

public class RouteInfo
{
    public string OriginDestination { get; set; }
    public string FinalDestination { get; set; }
    public decimal DistanceInKm { get; set; }
    public TimeSpan EstimatedTime { get; set; }
}

public class VehicleInfo
{
    public string RegistrationPlate { get; set; }
    public string Model { get; set; }
    public short Capacity { get; set; }
}

public class DriverInfo
{
    public string Name { get; set; }
    public string Surname { get; set; }
}