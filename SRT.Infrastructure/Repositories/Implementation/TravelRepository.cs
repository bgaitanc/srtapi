using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Travels;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class TravelRepository(SrtDbContext context) : Repository<Travel>(context), ITravelRepository
{
    public async Task<IEnumerable<GetTravelResponse>> GetTravels(Guid? travelId = null)
    {
        var list = GetAll()
            .Include(x => x.Route)
            .Include(x => x.Vehicle)
            .Include(x => x.Driver);

        var listMapped = list.Select(x => new GetTravelResponse
        {
            TravelId = x.Id,
            RouteId = x.RouteId,
            VehicleId = x.VehicleId,
            DriverId = x.DriverId,
            Price = x.Price,
            DepartureDate = x.DepartureDate,
            ArrivalDate = x.ArrivalDate,
            Status = x.Status,
            Route = new RouteInfo
            {
                OriginDestination = x.Route.OriginDestination.Name,
                FinalDestination = x.Route.FinalDestination.Name,
                DistanceInKm = x.Route.DistanceInKm,
                EstimatedTime = x.Route.EstimatedTime
            },
            Vehicle = new VehicleInfo
            {
                RegistrationPlate = x.Vehicle.RegistrationPlate,
                Model = x.Vehicle.Model,
                Capacity = x.Vehicle.Capacity
            },
            Driver = new DriverInfo
            {
                Name = x.Driver.Name,
                Surname = x.Driver.Surname
            }
        });

        if (travelId is not null)
            return await listMapped.Where(x => x.TravelId == travelId).ToListAsync();

        return await listMapped.ToListAsync();
    }

    public async Task<GetTravelResponse?> GetTravelById(Guid travelId)
    {
        var result = await GetTravels(travelId);
        return result.FirstOrDefault();
    }
}