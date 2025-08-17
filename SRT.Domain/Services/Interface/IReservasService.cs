using SRT.Domain.Models.Dtos.Reservas;

namespace SRT.Domain.Services.Interface;

public interface IReservasService
{
    Task<GetReservaInfoResponse> CreateReserva(CreateReservaRequest request);
    Task<IEnumerable<GetReservaInfoResponse>> GetDetalleReservasByUserId(int userId);
}