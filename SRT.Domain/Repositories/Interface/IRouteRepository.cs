using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Routes;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IRouteRepository : IRepository<Route>
{
    Task<Route?> GetRouteByParams(GetRouteRequest request);
    Task<IEnumerable<GetRouteWithNamesResponse>> GetRoutesWithNames();
}