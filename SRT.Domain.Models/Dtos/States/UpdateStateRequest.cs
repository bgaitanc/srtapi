namespace SRT.Domain.Models.Dtos.States;

public class UpdateStateRequest
{
    public required Guid StateId { get; set; }
    public required Guid CountryId { get; set; }
    public required string StateName { get; set; }
}