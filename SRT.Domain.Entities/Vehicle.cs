using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Vehicle : BaseEntity
{
    public required string RegistrationPlate { get; set; }
    public required string Model { get; set; }
    public required short Capacity { get; set; }
}