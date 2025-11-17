namespace SRT.Domain.Models.Dtos.Destinations;

public class UpdateDestinationRequest
{
    public required Guid DestinationId { get; set; }
    public required Guid StateId { get; set; }
    public required string DestinationName { get; set; }
}