using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Vehicles;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> GetVehicles();
    Task<Vehicle?> GetVehicleByParams(GetVehicleRequest request);
}