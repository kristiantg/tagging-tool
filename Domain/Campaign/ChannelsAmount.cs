namespace Domain.Campaign;

public sealed class ChannelsAmount()
{
    public ChannelsAmount(int value) : this()
    {
        Value = value;
    }
    
    public int Value { get; }
}