namespace Domain.Common;

public sealed record ChannelId()
{
    public ChannelId(Guid value) : this()
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Channel Id cannot be empty", nameof(CampaignId));
        }
        
        Value = value;
    }
    
    public Guid Value { get; }
}