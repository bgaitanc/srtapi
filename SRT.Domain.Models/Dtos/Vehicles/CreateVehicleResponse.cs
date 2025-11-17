namespace SRT.Domain.Models.Dtos.Vehicles;

public class CreateVehicleResponse : CreateVehicleRequest
{
    public Guid VehicleId { get; set; }
}