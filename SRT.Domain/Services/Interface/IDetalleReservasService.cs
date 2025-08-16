using SRT.Domain.Models.Dtos.Reservas;

namespace SRT.Domain.Services.Interface;

public interface IDetalleReservasService
{
    Task<GetDetalleReservasResponse> GetDetalleReservasByViajeId(int viajeId);
    Task<CreateDetalleReservaResponse> CreateDetalleReserva(CreateDetalleReservaRequest request);
}