namespace Domain.Common;

public sealed record TagId()
{
    public TagId(Guid value) : this()
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Tag Id cannot be empty", nameof(CampaignId));
        }
        
        Value = value;
    }
    
    public Guid Value { get; }
}