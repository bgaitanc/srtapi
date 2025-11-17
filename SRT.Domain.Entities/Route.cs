using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Route : BaseEntity
{
    public required Guid OriginDestinationId { get; set; }
    public required Guid FinalDestinationId { get; set; }
    public required decimal DistanceInKm { get; set; }
    public required TimeSpan EstimatedTime { get; set; }
    public Destination OriginDestination { get; set; }
    public Destination FinalDestination { get; set; }
}