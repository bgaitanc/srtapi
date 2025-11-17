using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Destinations;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IDestinationRepository : IRepository<Destination>
{
    Task<IEnumerable<Destination>> GetDestinations(Guid? stateId);
    Task<Destination?> GetDestinationByParams(GetDestinationRequest request);
}