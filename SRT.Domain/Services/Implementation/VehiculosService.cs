using SRT.Domain.Models.Dtos.Vehiculos;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class VehiculosService(IVehiculosRepository vehiculosRepository) : IVehiculosService
{
    public async Task<GetVehiculoResponse?> GetVehiculo(GetVehiculoRequest request)
    {
        if (request.VehiculoId is null && request.Placa is null && request.Modelo is null)
            throw new Exception("Para realizar la busqueda es necesario el id, placa o modelo del vehículo");

        var result = await vehiculosRepository.GetVehiculoByParams(request);
        return result is not null ? new GetVehiculoResponse(result) : null;
    }

    public async Task<IEnumerable<GetVehiculoResponse>> GetVehiculos()
    {
        var result = await vehiculosRepository.GetVehiculos();
        return result.Select(d => new GetVehiculoResponse(d));
    }

    public async Task<CreateVehiculoResponse> CreateVehiculo(CreateVehiculoRequest request)
    {
        var result = await vehiculosRepository.CreateVehiculo(request);
        return new CreateVehiculoResponse
        {
            VehiculoId = result,
            Placa = request.Placa,
            Modelo = request.Modelo,
            Capacidad = request.Capacidad,
        };
    }

    public async Task<UpdateVehiculoResponse> UpdateVehiculo(UpdateVehiculoRequest request)
    {
        await vehiculosRepository.UpdateVehiculo(request);

        return new UpdateVehiculoResponse
        {
            VehiculoId = request.VehiculoId
        };
    }

    public async Task EliminarReactivarVehiculo(int vehiculoId, bool activo)
    {
        await vehiculosRepository.DeleteOrReactiveVehiculo(vehiculoId, activo);
    }
}