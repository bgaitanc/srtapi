namespace SRT.Domain.Models.Dtos.Routes;

public class GetRouteRequest
{
    public Guid? RouteId { get; set; }
    public Guid? OriginDestinationId { get; set; }
    public Guid? FinalDestinationId { get; set; }
}