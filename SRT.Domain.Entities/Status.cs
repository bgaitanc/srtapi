using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Status : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}

