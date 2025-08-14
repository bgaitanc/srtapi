using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Vehiculos;
using SRT.Domain.Models.Dtos.Viajes;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IViajesRepository : IRepository<Viajes>
{
    Task<IEnumerable<GetViajesResponse>> GetViajes();
    Task<Vehiculos?> GetVehiculoByParams(GetVehiculoRequest request);
}