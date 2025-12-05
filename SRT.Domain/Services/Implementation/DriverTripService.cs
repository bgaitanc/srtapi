using SRT.Domain.Models.Dtos.DriverTrips;
using SRT.Domain.Models.Dtos.Travels;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;
using SRT.Domain.Utils.Exceptions;
using System.Net;

namespace SRT.Domain.Services.Implementation;

public class DriverTripService(ITravelRepository travelRepository, IReservationRepository reservationRepository) : IDriverTripService
{
    public async Task<IEnumerable<AssignedTripResponse>> GetAssignedTrips(Guid driverId, string? status, DateTime? date)
    {

        var travels = travelRepository.GetAllWithDetails().ToList();
        var assignedTravels = travels
            .Where(t => t.DriverId == driverId)
            .Where(t => string.IsNullOrEmpty(status) || t.Status.ToString() == status)
            .Where(t => !date.HasValue || t.DepartureDate.Date == date.Value.Date)
            .ToList();

        var travelIds = assignedTravels.Select(t => t.Id).ToList();
        var reservations = await reservationRepository.GetReservationsByTravelIds(travelIds);

        return assignedTravels.Select(travel => new AssignedTripResponse
        {
            TravelId = travel.Id,
            Route = new RouteInfo
            {
                OriginDestination = travel.Route?.OriginDestination?.Name ?? string.Empty,
                FinalDestination = travel.Route?.FinalDestination?.Name ?? string.Empty,
                DistanceInKm = travel.Route?.DistanceInKm ?? 0,
                EstimatedTime = travel.Route?.EstimatedTime ?? TimeSpan.Zero
            },
            DepartureDate = travel.DepartureDate,
            ArrivalDate = travel.ArrivalDate,
            Vehicle = travel.Vehicle == null ? new VehicleInfo() : new VehicleInfo
            {
                RegistrationPlate = travel.Vehicle.RegistrationPlate,
                Model = travel.Vehicle.Model,
                Capacity = travel.Vehicle.Capacity
            },
            PassengerCount = reservations.Where(r => r.TravelId == travel.Id).Sum(r => r.ReservationDetails.Count),
            Status = travel.Status.ToString()
        });
    }

    public async Task<bool?> CompleteTrip(Guid travelId, Guid driverId)
    {
        var travel = travelRepository.GetAllWithDetails().FirstOrDefault(t => t.Id == travelId);
        if (travel == null)
            throw new SrtException(HttpStatusCode.NotFound, "Viaje no encontrado");
        if (travel.DriverId != driverId)
            throw new SrtException(HttpStatusCode.Forbidden, "No tiene permiso para completar este viaje");
        if (travel.Status.ToString() == "Completed")
            return true;
        travel.Status = Entities.TravelStatus.Completed;
        await travelRepository.UpdateAsync(travel);
        return true;
    }
}
