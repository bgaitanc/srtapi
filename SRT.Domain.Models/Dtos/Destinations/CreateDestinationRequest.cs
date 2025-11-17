namespace SRT.Domain.Models.Dtos.Destinations;

public class CreateDestinationRequest
{
    public required Guid StateId { get; set; }
    public required string DestinationName { get; set; }
}