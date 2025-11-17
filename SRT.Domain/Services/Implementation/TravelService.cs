using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Travels;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class TravelService(ITravelRepository travelRepository) : ITravelService
{
    public async Task<IEnumerable<GetTravelResponse>> GetTravels()
    {
        var response = await travelRepository.GetTravels();
        return response;
    }

    public async Task<CreateTravelResponse> CreateTravel(CreateTravelRequest request)
    {
        var newTravel = new Travel
        {
            RouteId = request.RouteId,
            VehicleId = request.VehicleId,
            DriverId = request.DriverId,
            Price = request.Price,
            DepartureDate = request.DepartureDate,
            ArrivalDate = request.ArrivalDate
        };

        var result = await travelRepository.CreateAsync(newTravel);

        return new CreateTravelResponse
        {
            TravelId = result.Id,
            RouteId = request.RouteId,
            VehicleId = request.VehicleId,
            DriverId = request.DriverId,
            Price = request.Price,
            DepartureDate = request.DepartureDate,
            ArrivalDate = request.ArrivalDate
        };
    }
}