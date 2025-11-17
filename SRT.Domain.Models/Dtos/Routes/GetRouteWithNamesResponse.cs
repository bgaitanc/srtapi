namespace SRT.Domain.Models.Dtos.Routes;

public class GetRouteWithNamesResponse
{
    public Guid RouteId { get; set; }
    public Guid OriginDestinationId { get; set; }
    public string? OriginDestinationName { get; set; }
    public Guid FinalDestinationId { get; set; }
    public string? FinalDestinationName { get; set; }
    public decimal DistanceInKm { get; set; }
    public TimeSpan EstimatedTime { get; set; }
}
