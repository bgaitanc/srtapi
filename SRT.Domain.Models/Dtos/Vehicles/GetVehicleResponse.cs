namespace SRT.Domain.Models.Dtos.Vehicles;

public class GetVehicleResponse(Entities.Vehicle vehicle)
{
    public Guid VehicleId { get; set; } = vehicle.Id;
    public string RegistrationPlate { get; set; } = vehicle.RegistrationPlate;
    public string Model { get; set; } = vehicle.Model;
    public short Capacity { get; set; } = vehicle.Capacity;
}