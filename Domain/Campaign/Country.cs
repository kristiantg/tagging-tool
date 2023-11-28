namespace Domain.Campaign;

public sealed class Country()
{
    public Country(string? value) : this()
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }
    
    public string Value { get; }
}