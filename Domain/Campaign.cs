using Domain.Abstractions;
using Domain.Common;
using Domain.DomainEvents;

namespace Domain;

public class Campaign : Entity
{
    public Title Title { get; private set; }
    public Status Status { get; private set; }
    public LaunchDate LaunchDate { get; private set; }
    public TaggingCompleted TaggingCompleted { get; private set; } 
    public ChannelsAmount ChannelsAmount { get; private set; }
    public Country Country { get; private set; }
    public LastModified LastModified { get; private set; }
    public IsPending IsPending { get; private set; }
    public Brand Brand { get; private set; }

    public Campaign(CampaignId campaignId, Title title, Status status, LaunchDate launchDate, TaggingCompleted taggingCompleted, ChannelsAmount channelsAmount, Country country, LastModified lastModified, IsPending isPending, Brand brand) : base(campaignId)
    {
        Title = title;
        Status = status;
        LaunchDate = launchDate;
        TaggingCompleted = taggingCompleted;
        ChannelsAmount = channelsAmount;
        Country = country;
        LastModified = lastModified;
        IsPending = isPending;
        Brand = brand;
    }

    public static Campaign Create(Title title, Status status, LaunchDate launchDate, TaggingCompleted taggingCompleted, ChannelsAmount channelsAmount, Country country, LastModified lastModified, IsPending isPending, Brand brand)
    {
        var campaign = new Campaign(new CampaignId(Guid.NewGuid()), 
            title, 
            status,
            launchDate, 
            taggingCompleted,
            channelsAmount,
            country,
            lastModified,
            isPending,
            brand
            );
        
        campaign.Raise(new CampaignCreatedDomainEvent(campaign.CampaignId));
        
        return campaign;
    }

    public static void Delete(Campaign campaign)
    {
        campaign.Raise(new CampaignDeletedDomainEvent(campaign.CampaignId));
    }

    public static Campaign CreateUpdate(CampaignId guid, Title title, Status status, LaunchDate launchDate, TaggingCompleted taggingCompleted, ChannelsAmount channelsAmount, Country country, LastModified lastModified, IsPending isPending, Brand brand)
    {
        var campaign = new Campaign(guid, 
            title, 
            status,
            launchDate, 
            taggingCompleted,
            channelsAmount,
            country,
            lastModified,
            isPending,
            brand);
        
        campaign.Raise(new CampaignUpdatedDomainEvent(guid));

        return campaign;
    }
}