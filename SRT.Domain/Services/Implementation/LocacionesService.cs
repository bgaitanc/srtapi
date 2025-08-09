using SRT.Domain.Models.Dtos.Locaciones;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class LocacionesService(ILocacionesRepository locacionesRepository) : ILocacionesService
{
    public async Task<GetLocacionResponse?> GetLocacion(GetLocacionRequest request)
    {
        if (request.LocacionId is null && request.LocacionName is null)
            throw new Exception("Para realizar la busqueda es necesario el id o el nombre de la locación");

        var result = await locacionesRepository.GetLocacionByParams(request);
        return result is not null ? new GetLocacionResponse(result) : null;
    }

    public async Task<IEnumerable<GetLocacionResponse>> GetLocaciones(int? departamentoId)
    {
        var result = await locacionesRepository.GetLocaciones(departamentoId);
        return result.Select(d => new GetLocacionResponse(d));
    }

    public async Task<CreateLocacionResponse> CreateLocacion(CreateLocacionRequest request)
    {
        var result = await locacionesRepository.CreateLocacion(request);
        return new CreateLocacionResponse
        {
            LocacionId = result,
            DepartamentoId = request.DepartamentoId,
            LocacionName = request.LocacionName
        };
    }

    public async Task<UpdateLocacionResponse> UpdateLocacion(UpdateLocacionRequest request)
    {
        await locacionesRepository.UpdateLocacion(request);

        return new UpdateLocacionResponse
        {
            LocacionId = request.LocacionId
        };
    }

    public async Task EliminarReactivarLocacion(int locacionId, bool activo)
    {
        await locacionesRepository.DeleteOrReactiveLocacion(locacionId, activo);
    }
}