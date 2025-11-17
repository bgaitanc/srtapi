namespace SRT.Domain.Models.Dtos.Countries;

public class GetCountryRequest
{
    public Guid? CountryId { get; set; }
    public string? CountryName { get; set; }
}