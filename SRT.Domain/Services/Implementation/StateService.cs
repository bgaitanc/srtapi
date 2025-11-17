using System.Net;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.States;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;
using SRT.Domain.Utils.Exceptions;

namespace SRT.Domain.Services.Implementation;

public class StateService(IStateRepository stateRepository) : IStateService
{
    public async Task<GetStateResponse?> GetState(GetStateRequest request)
    {
        if (request.StateId is null && request.StateName is null)
            //TODO centralizar todos los mensajes, para poder reutilizar los mensajes genéricos
            throw new Exception("Para realizar la busqueda es necesario el id o el nombre del departamento");

        if (request.StateId is not null && request.StateName is not null)
            throw new Exception("Solo se puede buscar por id o por nombre, no ambos");
        
        var result = await stateRepository.GetStateByParams(request);
        return result is not null ? new GetStateResponse(result) : null;
    }

    public async Task<IEnumerable<GetStateResponse>> GetStates(Guid? paisId)
    {
        var result = await stateRepository.GetStates(paisId);
        return result.Select(d => new GetStateResponse(d));
    }

    public async Task<CreateStateResponse> CreateState(CreateStateRequest request)
    {
        var newState = new State
        {
            CountryId = request.CountryId,
            Name = request.StateName
        };

        var result = await stateRepository.CreateAsync(newState);

        return new CreateStateResponse
        {
            StateId = result.Id,
            CountryId = request.CountryId,
            StateName = request.StateName
        };
    }

    public async Task<UpdateStateResponse> UpdateState(UpdateStateRequest request)
    {
        var state = await stateRepository.GetByIdTrackingAsync(request.StateId);
        if (state is null)
        {
            throw new SrtException(HttpStatusCode.NotFound, "El departamento no existe");
        }

        state.Name = request.StateName;
        state.CountryId = request.CountryId;

        await stateRepository.UpdateAsync(state);

        return new UpdateStateResponse
        {
            StateId = request.StateId
        };
    }
}