using Domain.Abstractions;

namespace Domain.Campaign;

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

    public Campaign(Guid id, Title title, Status status, LaunchDate launchDate, TaggingCompleted taggingCompleted, ChannelsAmount channelsAmount, Country country, LastModified lastModified, IsPending isPending, Brand brand) : base(id)
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
        var campaign = new Campaign(Guid.NewGuid(), 
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
        
        campaign.Raise(new CampaignCreatedDomainEvent(campaign.Id));
        
        return campaign;
    }

    public static Campaign CreateUpdate(Guid guid, Title title, Status status, LaunchDate launchDate, TaggingCompleted taggingCompleted, ChannelsAmount channelsAmount, Country country, LastModified lastModified, IsPending isPending, Brand brand)
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