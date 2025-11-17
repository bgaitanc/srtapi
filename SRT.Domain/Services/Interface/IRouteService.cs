using SRT.Domain.Models.Dtos.Routes;

namespace SRT.Domain.Services.Interface;

public interface IRouteService
{
    Task<GetRouteResponse?> GetRoute(GetRouteRequest request);
    Task<IEnumerable<GetRouteWithNamesResponse>> GetRoutesWithNames();
    Task<CreateRouteResponse> CreateRoute(CreateRouteRequest request);
    Task<UpdateRouteResponse> UpdateRoute(UpdateRouteRequest request);
}