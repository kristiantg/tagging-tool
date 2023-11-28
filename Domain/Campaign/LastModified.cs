namespace Domain.Campaign;

public sealed class LastModified()
{
    public DateTime Value { get; } = DateTime.UtcNow;
}