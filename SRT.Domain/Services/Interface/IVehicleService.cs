using SRT.Domain.Models.Dtos.Vehicles;

namespace SRT.Domain.Services.Interface;

public interface IVehicleService
{
    Task<GetVehicleResponse?> GetVehicle(GetVehicleRequest request);
    Task<IEnumerable<GetVehicleResponse>> GetVehicles();
    Task<CreateVehicleResponse> CreateVehicle(CreateVehicleRequest request);
    Task<UpdateVehicleResponse> UpdateVehicle(UpdateVehicleRequest request);
}