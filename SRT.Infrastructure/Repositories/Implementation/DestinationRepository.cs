using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Destinations;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class DestinationRepository(SrtDbContext context)
    : Repository<Destination>(context), IDestinationRepository
{
    public async Task<IEnumerable<Destination>> GetDestinations(Guid? stateId)
    {
        var list = GetAll();
        return stateId.HasValue
            ? await list.Where(d => d.StateId == stateId).ToListAsync()
            : await list.ToListAsync();
    }

    public async Task<Destination?> GetDestinationByParams(GetDestinationRequest request)
    {
        var list = GetAll();

        if (request.DestinationId is not null)
            return await list.FirstOrDefaultAsync(d => d.StateId == request.DestinationId);
        
        return await list.FirstOrDefaultAsync(d => d.Name == request.DestinationName);
    }
}