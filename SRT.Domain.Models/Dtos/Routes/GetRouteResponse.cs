namespace SRT.Domain.Models.Dtos.Routes;

public class GetRouteResponse(Entities.Route route)
{
    public Guid RouteId { get; set; } = route.Id;
    public Guid OriginDestinationId { get; set; } = route.OriginDestinationId;
    public Guid FinalDestinationId { get; set; } = route.FinalDestinationId;
    public decimal DistanceInKm { get; set; } = route.DistanceInKm;
    public TimeSpan EstimatedTime { get; set; } = route.EstimatedTime;
}