using SRT.Domain.Models.Dtos.Reservas;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class ReservasService(IReservasRepository reservasRepository, IDetalleReservasService detalleReservasService)
    : IReservasService
{
    public async Task<CreateReservaResponse> CreateReserva(CreateReservaRequest request)
    {
        var result = await reservasRepository.CreateReserva(request);

        var detailResult = new List<CreateDetalleReservaResponse>();

        request.Detalle.AsParallel().ForAll(async (d) =>
        {
            var req = new CreateDetalleReservaRequest
            {
                ReservaId = result,
                NumeroAsiento = d
            };
            var dResult = await detalleReservasService.CreateDetalleReserva(req);
            detailResult.Add(dResult);
        });

        return new CreateReservaResponse
        {
            ReservaId = result,
            ClienteId = request.ClienteId,
            FechaReserva = request.FechaReserva,
            ViajeId = request.ViajeId,
            Detalle = detailResult
        };
    }
}