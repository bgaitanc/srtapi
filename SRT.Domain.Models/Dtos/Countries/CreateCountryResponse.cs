namespace SRT.Domain.Models.Dtos.Countries;

public class CreateCountryResponse : CreateCountryRequest
{
    public Guid CountryId { get; set; }
}