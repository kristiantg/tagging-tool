namespace Domain.Campaign.Common;

public sealed class Brand()
{
    public Brand(string? value) : this()
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }
    
    public string Value { get; }
}