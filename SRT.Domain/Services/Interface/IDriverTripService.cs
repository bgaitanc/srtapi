using SRT.Domain.Models.Dtos.DriverTrips;

namespace SRT.Domain.Services.Interface;

public interface IDriverTripService
{
    Task<IEnumerable<AssignedTripResponse>> GetAssignedTrips(Guid driverId, string? status, DateTime? date);
    Task<bool?> CompleteTrip(Guid travelId, Guid driverId);
}
