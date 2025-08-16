using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservas;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IReservasRepository : IRepository<Reservas>
{
    Task<int> CreateReserva(CreateReservaRequest request);

}
