using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Countries;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface ICountryRepository : IRepository<Country>
{
    Task<IEnumerable<Country>> GetCountries();
    Task<Country?> GetCountryByParams(GetCountryRequest request);
}