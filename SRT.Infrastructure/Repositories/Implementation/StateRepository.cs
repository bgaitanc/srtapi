using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.States;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class StateRepository(SrtDbContext context) : Repository<State>(context), IStateRepository
{
    public async Task<IEnumerable<State>> GetStates(Guid? countryId)
    {
        var list = GetAll();
        return countryId.HasValue
            ? await list.Where(x => x.CountryId == countryId).ToListAsync()
            : await list.ToListAsync();
    }

    public async Task<State?> GetStateByParams(GetStateRequest request)
    {
        var list = GetAll();

        if (request.StateId is not null)
            return await list.FirstOrDefaultAsync(c => c.Id == request.StateId);

        return await list.FirstOrDefaultAsync(c => c.Name == request.StateName);
    }
}