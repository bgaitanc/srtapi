using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class State : BaseEntity
{
    public required string Name { get; set; }
    public required Guid CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<Destination> Destinations { get; set; }
}