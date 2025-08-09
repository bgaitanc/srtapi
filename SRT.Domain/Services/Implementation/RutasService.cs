using SRT.Domain.Models.Dtos.Rutas;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class RutasService(IRutasRepository rutasRepository) : IRutasService
{
    public async Task<GetRutaResponse?> GetRuta(GetRutaRequest request)
    {
        if (request.RutaId is null && request.LocacionOrigenId is null && request.LocacionDestinoId is null)
            throw new Exception("Para realizar la busqueda es necesario el id, origen o destino de la ruta");

        var result = await rutasRepository.GetRutaByParams(request);
        return result is not null ? new GetRutaResponse(result) : null;
    }

    public async Task<IEnumerable<GetRutaResponse>> GetRutas()
    {
        var result = await rutasRepository.GetRutas();
        return result.Select(d => new GetRutaResponse(d));
    }

    public async Task<CreateRutaResponse> CreateRuta(CreateRutaRequest request)
    {
        var result = await rutasRepository.CreateRuta(request);
        return new CreateRutaResponse
        {
            RutaId = result,
            LocacionOrigenId = request.LocacionOrigenId,
            LocacionDestinoId = request.LocacionDestinoId,
            DistanciaKm = request.DistanciaKm,
            TiempoEstimado = request.TiempoEstimado
        };
    }

    public async Task<UpdateRutaResponse> UpdateRuta(UpdateRutaRequest request)
    {
        await rutasRepository.UpdateRuta(request);

        return new UpdateRutaResponse
        {
            RutaId = request.RutaId
        };
    }

    public async Task EliminarReactivarRuta(int rutaId, bool activo)
    {
        await rutasRepository.DeleteOrReactiveRuta(rutaId, activo);
    }
}