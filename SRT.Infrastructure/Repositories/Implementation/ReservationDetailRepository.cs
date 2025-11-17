using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservations;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class ReservationDetailRepository(SrtDbContext context)
    : Repository<ReservationDetail>(context), IReservationDetailRepository
{
    public async Task<GetReservationDetailResponse> GetReservationDetailByTravelId(Guid travelId)
    {
        var list = GetAll()
            .Include(x => x.Reservation)
            .ThenInclude(x => x.Travel)
            .ThenInclude(x => x.Vehicle)
            .Where(x => x.Reservation.TravelId == travelId)
            .GroupBy(g => new
            {
                g.Reservation.Travel.Id,
                g.Reservation.Travel.Vehicle.Capacity,
            })
            .Select(x => new GetReservationDetailResponse
            {
                TravelId = x.Key.Id,
                Capacity = x.Key.Capacity,
                ReservedSeats = x.Select(y => y.SeatNumber).ToList()
            });

        return (await list.FirstOrDefaultAsync())!;
    }
}