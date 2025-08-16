using SRT.Domain.Models.Dtos.Reservas;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class DetalleReservasService(IDetalleReservasRepository detalleReservasRepository) : IDetalleReservasService
{
    public async Task<GetDetalleReservasResponse> GetDetalleReservasByViajeId(int viajeId)
    {
        return await detalleReservasRepository.GetDetalleReservasByViajeId(viajeId);
    }

    public async Task<CreateDetalleReservaResponse> CreateDetalleReserva(CreateDetalleReservaRequest request)
    {
        var result = await detalleReservasRepository.CreateDetalleReserva(request);
        return new CreateDetalleReservaResponse
        {
            DetalleReservaId = result,
            ReservaId = request.ReservaId,
            NumeroAsiento = request.NumeroAsiento
        };
    }
}