namespace SRT.Domain.Models.Dtos.Countries;

public class UpdateCountryRequest
{
    public required Guid CountryId { get; set; }
    public required string CountryName { get; set; }
}