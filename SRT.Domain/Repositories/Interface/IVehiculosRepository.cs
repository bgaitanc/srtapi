using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Vehiculos;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IVehiculosRepository : IRepository<Vehiculos>
{
    Task<IEnumerable<Vehiculos>> GetVehiculos();
    Task<Vehiculos?> GetVehiculoByParams(GetVehiculoRequest request);
    Task<int> CreateVehiculo(CreateVehiculoRequest request);
    Task<int> UpdateVehiculo(UpdateVehiculoRequest request);
    Task<int> DeleteOrReactiveVehiculo(int vehiculoId, bool activo);
}