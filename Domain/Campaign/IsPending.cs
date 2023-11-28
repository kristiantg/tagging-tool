namespace Domain.Campaign;

public sealed class IsPending()
{
    public IsPending(bool value) : this()
    {
        Value = value;
    }
    
    public bool Value { get; }
}