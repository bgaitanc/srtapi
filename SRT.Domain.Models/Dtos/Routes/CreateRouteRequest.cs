namespace SRT.Domain.Models.Dtos.Routes;

public class CreateRouteRequest
{
    public required Guid OriginDestinationId { get; set; }
    public required Guid FinalDestinationId { get; set; }
    public required decimal DistanceInKm { get; set; }
    public required TimeSpan EstimatedTime { get; set; }
}