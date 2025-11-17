namespace SRT.Domain.Models.Helpers;

public class AppSettings
{
    public required string Secret { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
}