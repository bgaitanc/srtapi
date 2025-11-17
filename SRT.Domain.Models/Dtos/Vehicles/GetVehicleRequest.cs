namespace SRT.Domain.Models.Dtos.Vehicles;

public class GetVehicleRequest
{
    public Guid? VehicleId { get; set; }
    public string? RegistrationPlate { get; set; }
    public string? Model { get; set; }
}