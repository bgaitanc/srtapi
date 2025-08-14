using SRT.Domain.Models.Dtos.Viajes;

namespace SRT.Domain.Services.Interface;

public interface IViajesService
{
    Task<IEnumerable<GetViajesResponse>> GetViajes();
}