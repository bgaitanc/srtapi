namespace SRT.Domain.Models.Dtos.Travels;

public class GetTravelInfoResponse
{
    public decimal Price { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
}