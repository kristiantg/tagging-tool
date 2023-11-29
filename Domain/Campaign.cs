using Domain.Abstractions;
using Domain.Common;
using Domain.DomainEvents;

namespace Domain;

public class Campaign : Entity
{
    public CampaignId CampaignId { get; private set; }
    public Name Name { get; private set; }
    public Status Status { get; private set; }
    public TagStatus TagStatus { get; private set; }
    public Tags Tags { get; private set; }
    public LastModified LastModified { get; private set; }
    public Created Created { get; private set; }
    
    public Campaign(Guid id, CampaignId campaignId, Name name, Status status, TagStatus tagStatus, Tags tags, LastModified lastModified, Created created) : base(id)
    {
        CampaignId = campaignId;
        Name = name;
        Status = status;
        TagStatus = tagStatus;
        Tags = tags;
        LastModified = lastModified;
        Created = created;
    }

    public static Campaign Create(Name name, Status status, TagStatus tagStatus, Tags tags, LastModified lastModified, Created created)
    {
        var campaign = new Campaign(Guid.NewGuid(), 
            new CampaignId(Guid.NewGuid()),
            name, 
            status, 
            tagStatus, 
            tags, 
            lastModified, 
            created
            );
        
        campaign.Raise(new CampaignCreatedDomainEvent(campaign.CampaignId));
        
        return campaign;
    }

    public static Guid Delete(Campaign campaign)
    {
        campaign.Raise(new CampaignDeletedDomainEvent(campaign.CampaignId));
        return campaign.CampaignId.Value;
    }

    public static Campaign CreateUpdate(Guid guid, CampaignId campaignId, Name name, Status status, TagStatus tagStatus, Tags tags, LastModified lastModified, Created created)
    {
        var campaign = new Campaign(guid, 
            campaignId,
            name, 
            status, 
            tagStatus, 
            tags, 
            lastModified, 
            created);
        
        campaign.Raise(new CampaignUpdatedDomainEvent(campaignId));

        return campaign;
    }
}