using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservations;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IReservationRepository : IRepository<Reservation>
{
    Task<IEnumerable<GetReservationResponse>> GetReservationsByUserId(Guid userId);
}
