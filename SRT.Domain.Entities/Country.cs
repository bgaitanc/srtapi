using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Country : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<State> States { get; set; }
}