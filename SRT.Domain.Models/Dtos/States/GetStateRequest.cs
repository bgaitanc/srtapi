namespace SRT.Domain.Models.Dtos.States;

public class GetStateRequest
{
    public Guid? StateId { get; set; }
    public string? StateName { get; set; }
}