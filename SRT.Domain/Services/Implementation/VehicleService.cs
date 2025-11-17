using System.Net;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Vehicles;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;
using SRT.Domain.Utils.Exceptions;

namespace SRT.Domain.Services.Implementation;

public class VehicleService(IVehicleRepository vehicleRepository) : IVehicleService
{
    public async Task<GetVehicleResponse?> GetVehicle(GetVehicleRequest request)
    {
        if (request.VehicleId is null && request.RegistrationPlate is null && request.Model is null)
            throw new Exception("Para realizar la busqueda es necesario el id, placa o modelo del vehículo");

        if (request.VehicleId is not null && request.RegistrationPlate is not null && request.Model is not null)
            throw new Exception("Solo se puede buscar por id, placa o model, no todos");

        var result = await vehicleRepository.GetVehicleByParams(request);
        return result is not null ? new GetVehicleResponse(result) : null;
    }

    public async Task<IEnumerable<GetVehicleResponse>> GetVehicles()
    {
        var result = await vehicleRepository.GetVehicles();
        return result.Select(d => new GetVehicleResponse(d));
    }

    public async Task<CreateVehicleResponse> CreateVehicle(CreateVehicleRequest request)
    {
        var newVehicle = new Vehicle
        {
            RegistrationPlate = request.RegistrationPlate,
            Model = request.Model,
            Capacity = request.Capacity
        };

        var result = await vehicleRepository.CreateAsync(newVehicle);
        return new CreateVehicleResponse
        {
            VehicleId = result.Id,
            RegistrationPlate = request.RegistrationPlate,
            Model = request.Model,
            Capacity = request.Capacity
        };
    }

    public async Task<UpdateVehicleResponse> UpdateVehicle(UpdateVehicleRequest request)
    {
        var vehicle = await vehicleRepository.GetByIdTrackingAsync(request.VehicleId);
        if (vehicle is null)
        {
            throw new SrtException(HttpStatusCode.NotFound, "El vehículo no existe");
        }

        vehicle.RegistrationPlate = request.RegistrationPlate;
        vehicle.Model = request.Model;
        vehicle.Capacity = request.Capacity;

        await vehicleRepository.UpdateAsync(vehicle);

        return new UpdateVehicleResponse
        {
            VehicleId = request.VehicleId
        };
    }
}