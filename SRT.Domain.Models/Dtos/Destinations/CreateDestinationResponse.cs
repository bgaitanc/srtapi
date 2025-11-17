namespace SRT.Domain.Models.Dtos.Destinations;

public class CreateDestinationResponse : CreateDestinationRequest
{
    public Guid DestinationId { get; set; }
}