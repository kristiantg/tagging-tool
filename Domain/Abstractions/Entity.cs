using Domain.Common;

namespace Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    protected Entity(CampaignId campaignId)
    {
        CampaignId = campaignId;
    }
    public CampaignId CampaignId { get; init; }
    public List<IDomainEvent> DomainEvents => _domainEvents.ToList();

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}