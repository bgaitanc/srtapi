using SRT.Domain.Models.Dtos.Viajes;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class ViajesService(IViajesRepository viajesRepository) : IViajesService
{
    public async Task<IEnumerable<GetViajesResponse>> GetViajes()
    {
        var response = await viajesRepository.GetViajes();
        return response;
    }
}