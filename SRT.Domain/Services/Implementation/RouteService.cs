using System.Net;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Routes;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;
using SRT.Domain.Utils.Exceptions;

namespace SRT.Domain.Services.Implementation;

public class RouteService(IRouteRepository routeRepository) : IRouteService
{
    public async Task<GetRouteResponse?> GetRoute(GetRouteRequest request)
    {
        if (request.RouteId is null && request.OriginDestinationId is null && request.FinalDestinationId is null)
            throw new Exception("Para realizar la busqueda es necesario el id, origen o destino de la ruta");

        if (request.RouteId is not null && request.OriginDestinationId is not null && request.FinalDestinationId is not null)
            throw new Exception("Solo se puede buscar por id, origen o destino, no todos");
        
        var result = await routeRepository.GetRouteByParams(request);
        return result is not null ? new GetRouteResponse(result) : null;
    }

    public async Task<IEnumerable<GetRouteWithNamesResponse>> GetRoutesWithNames()
    {
        return await routeRepository.GetRoutesWithNames();
    }

    public async Task<CreateRouteResponse> CreateRoute(CreateRouteRequest request)
    {
        var newRoute = new Route
        {
            OriginDestinationId = request.OriginDestinationId,
            FinalDestinationId = request.FinalDestinationId,
            DistanceInKm = request.DistanceInKm,
            EstimatedTime = request.EstimatedTime
        };

        var result = await routeRepository.CreateAsync(newRoute);
        return new CreateRouteResponse
        {
            RouteId = result.Id,
            OriginDestinationId = request.OriginDestinationId,
            FinalDestinationId = request.FinalDestinationId,
            DistanceInKm = request.DistanceInKm,
            EstimatedTime = request.EstimatedTime
        };
    }

    public async Task<UpdateRouteResponse> UpdateRoute(UpdateRouteRequest request)
    {
        var route = await routeRepository.GetByIdTrackingAsync(request.RouteId);
        if (route is null)
        {
            // TODO se puede crear una utilidad comun para mandar esta excepción
            throw new SrtException(HttpStatusCode.NotFound, "La ruta no existe");
        }
        
        route.OriginDestinationId = request.OriginDestinationId;
        route.FinalDestinationId = request.FinalDestinationId;
        route.DistanceInKm = request.DistanceInKm;
        route.EstimatedTime = request.EstimatedTime;
        
        await routeRepository.UpdateAsync(route);

        return new UpdateRouteResponse
        {
            RouteId = request.RouteId
        };
    }
}