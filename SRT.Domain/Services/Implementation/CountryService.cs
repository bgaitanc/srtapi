using System.Net;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Countries;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;
using SRT.Domain.Utils.Exceptions;

namespace SRT.Domain.Services.Implementation;

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public async Task<GetCountryResponse?> GetCountry(GetCountryRequest request)
    {
        if (request.CountryId is null && request.CountryName is null)
            throw new Exception("Para realizar la busqueda es necesario el id o el nombre del Country");

        if (request.CountryId is not null && request.CountryName is not null)
            throw new Exception("Solo se puede buscar por id o por nombre, no ambos");

        var result = await countryRepository.GetCountryByParams(request);
        return result is not null ? new GetCountryResponse(result) : null;
    }

    public async Task<IEnumerable<GetCountryResponse>> GetCountries()
    {
        var result = await countryRepository.GetCountries();
        return result.Select(p => new GetCountryResponse(p));
    }

    public async Task<CreateCountryResponse> CreateCountry(CreateCountryRequest request)
    {
        var newCountry = new Country
        {
            Name = request.CountryName
        };

        var result = await countryRepository.CreateAsync(newCountry);
        return new CreateCountryResponse
        {
            CountryId = result.Id,
            CountryName = request.CountryName
        };
    }

    public async Task<UpdateCountryResponse> UpdateCountry(UpdateCountryRequest request)
    {
        var country = await countryRepository.GetByIdTrackingAsync(request.CountryId);
        if (country is null)
        {
            throw new SrtException(HttpStatusCode.NotFound, "El pais no existe");
        }

        country.Name = request.CountryName;

        await countryRepository.UpdateAsync(country);

        return new UpdateCountryResponse
        {
            CountryId = request.CountryId
        };
    }
}