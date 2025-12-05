using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Travels;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface ITravelRepository : IRepository<Travel>
{
    Task<IEnumerable<GetTravelResponse>> GetTravels(Guid? travelId = null);
    Task<GetTravelResponse?> GetTravelById(Guid travelId);
    IQueryable<Travel> GetAllWithDetails();
}