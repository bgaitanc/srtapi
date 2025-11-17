using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Routes;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class RouteRepository(SrtDbContext context) : Repository<Route>(context), IRouteRepository
{
    public async Task<IEnumerable<GetRouteWithNamesResponse>> GetRoutesWithNames()
    {
        return await GetAll()
            .Include(r => r.OriginDestination)
            .Include(r => r.FinalDestination)
            .Select(x => new GetRouteWithNamesResponse
            {
                RouteId = x.Id,
                OriginDestinationId = x.OriginDestinationId,
                OriginDestinationName = x.OriginDestination.Name,
                FinalDestinationId = x.FinalDestinationId,
                FinalDestinationName = x.FinalDestination.Name,
                DistanceInKm = x.DistanceInKm,
                EstimatedTime = x.EstimatedTime
            }).ToListAsync();
    }

    public async Task<Route?> GetRouteByParams(GetRouteRequest request)
    {
        var list = GetAll();

        if (request.RouteId is not null)
            return await list.FirstOrDefaultAsync(r => r.Id == request.RouteId);

        if (request.OriginDestinationId is not null)
            return await list.FirstOrDefaultAsync(r => r.OriginDestinationId == request.OriginDestinationId);

        return await list.FirstOrDefaultAsync(r => r.FinalDestinationId == request.FinalDestinationId);
    }
}