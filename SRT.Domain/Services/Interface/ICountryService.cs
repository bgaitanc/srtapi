using SRT.Domain.Models.Dtos.Countries;

namespace SRT.Domain.Services.Interface;

public interface ICountryService
{
    Task<GetCountryResponse?> GetCountry(GetCountryRequest request);
    Task<IEnumerable<GetCountryResponse>> GetCountries();
    Task<CreateCountryResponse> CreateCountry(CreateCountryRequest request);
    Task<UpdateCountryResponse> UpdateCountry(UpdateCountryRequest request);
}