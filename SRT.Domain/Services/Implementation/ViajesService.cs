using SRT.Domain.Models.Dtos.Viajes;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class ViajesService(IViajesRepository viajesRepository) : IViajesService
{
    public async Task<IEnumerable<GetViajesResponse>> GetViajes()
    {
        var response = await viajesRepository.GetViajes();
        return response;
    }

    public async Task<CreateViajeResponse> CreateViaje(CreateViajeRequest request)
    {
        var result = await viajesRepository.CreateViaje(request);

        return new CreateViajeResponse
        {
            ViajeId = result,
            RutaId = request.RutaId,
            VehiculoId = request.VehiculoId,
            ConductorId = request.ConductorId,
            Costo = request.Costo,
            FechaHoraSalida = request.FechaHoraSalida,
            FechaHoraLlegada = request.FechaHoraLlegada
        };
    }
}