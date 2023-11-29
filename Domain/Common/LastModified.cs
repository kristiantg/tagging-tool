namespace Domain.Common;

public sealed class LastModified()
{
    public DateTime Value { get; } = DateTime.UtcNow;
}