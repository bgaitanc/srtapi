namespace SRT.Domain.Models.Dtos.Countries;

public class GetCountryResponse(Entities.Country country)
{
    public Guid Id { get; set; } = country.Id;
    public string Name { get; set; } = country.Name;
}