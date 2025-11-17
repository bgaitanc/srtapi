using SRT.Domain.Models.Dtos.Travels;

namespace SRT.Domain.Services.Interface;

public interface ITravelService
{
    Task<IEnumerable<GetTravelResponse>> GetTravels();
    Task<CreateTravelResponse> CreateTravel(CreateTravelRequest request);
}