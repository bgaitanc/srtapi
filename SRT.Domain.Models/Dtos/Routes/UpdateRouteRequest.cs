namespace SRT.Domain.Models.Dtos.Routes;

public class UpdateRouteRequest
{
    public required Guid RouteId { get; set; }
    public required Guid OriginDestinationId { get; set; }
    public required Guid FinalDestinationId { get; set; }
    public required decimal DistanceInKm { get; set; }
    public required TimeSpan EstimatedTime { get; set; }
}