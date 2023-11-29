namespace Domain.Common;

public sealed class TaggingCompleted()
{
    public TaggingCompleted(bool value) : this()
    {
        Value = value;
    }
    
    public bool Value { get; }
}