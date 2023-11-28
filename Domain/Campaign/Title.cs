namespace Domain.Campaign;

public sealed class Title()
{
    public Title(string? value) : this()
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }
    
    public string? Value { get; }
}