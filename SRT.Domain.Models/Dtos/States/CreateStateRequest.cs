namespace SRT.Domain.Models.Dtos.States;

public class CreateStateRequest
{
    public required Guid CountryId { get; set; }
    public required string StateName { get; set; }
}