using SRT.Domain.Models.Dtos.Destinations;

namespace SRT.Domain.Services.Interface;

public interface IDestinationService
{
    Task<GetDestinationResponse?> GetDestination(GetDestinationRequest request);
    Task<IEnumerable<GetDestinationResponse>> GetDestinations(Guid? stateId);
    Task<CreateDestinationResponse> CreateDestination(CreateDestinationRequest request);
    Task<UpdateDestinationResponse> UpdateDestination(UpdateDestinationRequest request);
}