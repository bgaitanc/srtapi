namespace SRT.Domain.Models.Dtos.States;

public class GetStateResponse(Entities.State state)
{
    public Guid Id { get; set; } = state.Id;
    public Guid CountryId { get; set; } = state.CountryId;
    public string Name { get; set; } = state.Name;
}