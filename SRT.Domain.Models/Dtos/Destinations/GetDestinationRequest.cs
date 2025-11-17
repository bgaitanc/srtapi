namespace SRT.Domain.Models.Dtos.Destinations;

public class GetDestinationRequest
{
    public Guid? DestinationId { get; set; }
    public string? DestinationName { get; set; }
}