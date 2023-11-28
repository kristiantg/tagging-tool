using Domain.Abstractions;

namespace Domain.Campaign;

public class Campaign : Entity
{
    public Name Name { get; private set; }

    public Campaign(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public static Campaign Create(Name name)
    {
        var campaign = new Campaign(Guid.NewGuid(), name);
        
        campaign.Raise(new CampaignCreatedDomainEvent(campaign.Id));
        
        return campaign;
    }

    public static Campaign CreateUpdate(Guid guid, Name name)
    {
        var campaign = new Campaign(guid, name);
        
        campaign.Raise(new CampaignUpdatedDomainEvent(guid));

        return campaign;
    }
}