using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.States;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IStateRepository : IRepository<State>
{
    Task<IEnumerable<State>> GetStates(Guid? countryId);
    Task<State?> GetStateByParams(GetStateRequest request);
}