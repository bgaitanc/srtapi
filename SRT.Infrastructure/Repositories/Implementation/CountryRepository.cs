using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Countries;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class CountryRepository(SrtDbContext context) : Repository<Country>(context), ICountryRepository
{
    public async Task<IEnumerable<Country>> GetCountries()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Country?> GetCountryByParams(GetCountryRequest request)
    {
        var list = GetAll();

        if (request.CountryId is not null)
            return await list.FirstOrDefaultAsync(c => c.Id == request.CountryId);

        return await list.FirstOrDefaultAsync(c => c.Name == request.CountryName);
    }
}