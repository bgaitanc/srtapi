using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservations;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class ReservationRepository(SrtDbContext context) : Repository<Reservation>(context), IReservationRepository
{
    public async Task<IEnumerable<GetReservationResponse>> GetReservationsByUserId(Guid userId)
    {
        var list = GetAll()
            .Include(x => x.Travel)
            .Include(x => x.ReservationDetails);

        return await list.Where(x => x.ClientId == userId)
            .Select(x => new GetReservationResponse
            {
                ReservationId = x.Id,
                TravelId = x.TravelId,
                ReservationDate = x.ReservationDate,
                Detail = x.ReservationDetails.Select(d => new CreateReservationDetailResponse
                {
                    ReservationDetailId = d.Id,
                    ReservationId = d.ReservationId,
                    SeatNumber = d.SeatNumber
                }).ToList()
            }).ToListAsync();
    }
}