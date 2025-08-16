using SRT.Domain.Models.Dtos.Reservas;

namespace SRT.Domain.Services.Interface;

public interface IReservasService
{
    Task<CreateReservaResponse> CreateReserva(CreateReservaRequest request);
}