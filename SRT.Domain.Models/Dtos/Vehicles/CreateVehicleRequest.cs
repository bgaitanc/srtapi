namespace SRT.Domain.Models.Dtos.Vehicles;

public class CreateVehicleRequest
{
    public required string RegistrationPlate { get; set; }
    public required string Model { get; set; }
    public required short Capacity { get; set; }
}