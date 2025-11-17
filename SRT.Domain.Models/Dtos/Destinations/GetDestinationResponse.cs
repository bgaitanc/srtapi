namespace SRT.Domain.Models.Dtos.Destinations;

public class GetDestinationResponse(Entities.Destination destination)
{
    public Guid DestinationId { get; set; } = destination.Id;
    public Guid StateId { get; set; } = destination.StateId;
    public string DestinationName { get; set; } = destination.Name;
}