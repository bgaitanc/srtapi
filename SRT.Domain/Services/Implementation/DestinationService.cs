using System.Net;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Destinations;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;
using SRT.Domain.Utils.Exceptions;

namespace SRT.Domain.Services.Implementation;

public class DestinationService(IDestinationRepository destinationRepository) : IDestinationService
{
    public async Task<GetDestinationResponse?> GetDestination(GetDestinationRequest request)
    {
        if (request.DestinationId is null && request.DestinationName is null)
            throw new Exception("Para realizar la busqueda es necesario el id o el nombre del destino");

        if (request.DestinationId is not null && request.DestinationName is not null)
            throw new Exception("Solo se puede buscar por id o por nombre, no ambos");

        var result = await destinationRepository.GetDestinationByParams(request);
        return result is not null ? new GetDestinationResponse(result) : null;
    }

    public async Task<IEnumerable<GetDestinationResponse>> GetDestinations(Guid? stateId)
    {
        var result = await destinationRepository.GetDestinations(stateId);
        return result.Select(d => new GetDestinationResponse(d));
    }

    public async Task<CreateDestinationResponse> CreateDestination(CreateDestinationRequest request)
    {
        var newDestination = new Destination
        {
            StateId = request.StateId,
            Name = request.DestinationName
        };

        var result = await destinationRepository.CreateAsync(newDestination);
        return new CreateDestinationResponse
        {
            DestinationId = result.Id,
            StateId = request.StateId,
            DestinationName = request.DestinationName
        };
    }

    public async Task<UpdateDestinationResponse> UpdateDestination(UpdateDestinationRequest request)
    {
        var destination = await destinationRepository.GetByIdTrackingAsync(request.DestinationId);
        if (destination is null)
        {
            throw new SrtException(HttpStatusCode.NotFound, "El destino no existe");
        }

        destination.Name = request.DestinationName;
        destination.StateId = request.StateId;

        await destinationRepository.UpdateAsync(destination);

        return new UpdateDestinationResponse
        {
            DestinationId = request.DestinationId
        };
    }
}