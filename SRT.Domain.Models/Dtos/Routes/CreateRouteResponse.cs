namespace SRT.Domain.Models.Dtos.Routes;

public class CreateRouteResponse : CreateRouteRequest
{
    public Guid RouteId { get; set; }
}