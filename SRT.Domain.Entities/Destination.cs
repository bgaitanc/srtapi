using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Destination : BaseEntity
{
    public required string Name {get; set;}
    public required Guid StateId { get; set; }
    public State State { get; set; }
    public ICollection<Route> OriginRoutes { get; set; }
    public ICollection<Route> FinalRoutes { get; set; }
}