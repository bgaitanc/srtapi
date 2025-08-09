using SRT.Domain.Models.Dtos.Vehiculos;

namespace SRT.Domain.Services.Interface;

public interface IVehiculosService
{
    Task<GetVehiculoResponse?> GetVehiculo(GetVehiculoRequest request);
    Task<IEnumerable<GetVehiculoResponse>> GetVehiculos();
    Task<CreateVehiculoResponse> CreateVehiculo(CreateVehiculoRequest request);
    Task<UpdateVehiculoResponse> UpdateVehiculo(UpdateVehiculoRequest request);
    Task EliminarReactivarVehiculo(int vehiculoId, bool activo);
}