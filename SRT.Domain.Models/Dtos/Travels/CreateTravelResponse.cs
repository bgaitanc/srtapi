namespace SRT.Domain.Models.Dtos.Travels;

public class CreateTravelResponse : CreateTravelRequest
{
    public Guid TravelId { get; set; }
}