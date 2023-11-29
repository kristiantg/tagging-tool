namespace Domain.Common;

public sealed record CampaignId()
{
    public CampaignId(Guid value) : this()
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Campaign Id cannot be empty", nameof(CampaignId));
        }
        
        Value = value;
    }
    
    public Guid Value { get; }
}