namespace Domain.Campaign;

public sealed class Status()
{
    public Status(string? value) : this()
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }
    
    public string Value { get; }
}