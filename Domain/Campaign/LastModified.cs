namespace Domain.Campaign;

public sealed class LastModified()
{
    public LastModified(DateTime value) : this()
    {
        Value = value;
    }
    
    public DateTime Value { get; }
}