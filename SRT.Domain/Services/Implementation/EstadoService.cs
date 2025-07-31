using SRT.Domain.Models.Dtos.Estados;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class EstadoService(IEstadosRepository estadosRepository) : IEstadoService
{
    public async Task<GetEstadoResponse?> GetEstado(GetEstadoRequest request)
    {
        if (request.EstadoId is null && request.EstadoName is null)
            throw new Exception("Para realizar la busqueda es necesario el id o el nombre del estado");

        var result = await estadosRepository.GetEstadoByParams(request);
        return result is not null ? new GetEstadoResponse(result) : null;
    }

    public async Task<IEnumerable<GetEstadoResponse>> GetEstados()
    {
        var result = await estadosRepository.GetEstados();
        return result.Select(e => new GetEstadoResponse(e));
    }

    public async Task<CreateEstadoResponse> CreateEstado(CreateEstadoRequest request)
    {
        var result = await estadosRepository.CreateEstado(request);
        return new CreateEstadoResponse
        {
            EstadoId = result,
            EstadoName = request.EstadoName
        };
    }

    public async Task<UpdateEstadoResponse> UpdateEstado(UpdateEstadoRequest request)
    {
        await estadosRepository.UpdateEstado(request);
        
        return new UpdateEstadoResponse
        {
            EstadoId = request.EstadoId
        };
    }

    public async Task  EliminarReactivarEstado(int estadoId, bool activo)
    {
        await estadosRepository.UpdateOrReactiveEstado(estadoId, activo);
    }
}