namespace SRT.Domain.Models.Dtos.States;

public class CreateStateResponse : CreateStateRequest
{
    public Guid StateId { get; set; }
}