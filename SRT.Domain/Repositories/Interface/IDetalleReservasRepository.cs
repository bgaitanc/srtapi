using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservas;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IDetalleReservasRepository : IRepository<DetalleReservas>
{
    Task<GetDetalleReservasResponse> GetDetalleReservasByViajeId(int viajeId);
    Task<int> CreateDetalleReserva(CreateDetalleReservaRequest request);

}