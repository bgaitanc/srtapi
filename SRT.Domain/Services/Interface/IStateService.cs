using SRT.Domain.Models.Dtos.States;

namespace SRT.Domain.Services.Interface;

public interface IStateService
{
    Task<GetStateResponse?> GetState(GetStateRequest request);
    Task<IEnumerable<GetStateResponse>> GetStates(Guid? paisId);
    Task<CreateStateResponse> CreateState(CreateStateRequest request);
    Task<UpdateStateResponse> UpdateState(UpdateStateRequest request);
}