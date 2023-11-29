using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public class Channel : Entity
{
    public ChannelId ChannelId { get; private set; }
    public CampaignId CampaignId { get; private set; }
    public Title Title { get; private set; }
    public LaunchDate LaunchDate { get; private set; }
    public LastModified LastModified { get; private set; }
    public Created Created { get; private set; }

    public Channel(Guid id, ChannelId channelId, CampaignId campaignId, Title title, LaunchDate launchDate, LastModified lastModified, Created created) : base(id)
    {
        ChannelId = channelId;
        CampaignId = campaignId;
        Title = title;
        LaunchDate = launchDate;
        LastModified = lastModified;
        Created = created;
    }
    
    public static Channel Create(CampaignId campaignId, Title title, LaunchDate launchDate)
    {
        var channel = new Channel(Guid.NewGuid(), new ChannelId(Guid.NewGuid()), campaignId, title, launchDate, new LastModified(DateTime.UtcNow), new Created(DateTime.UtcNow));
        
        channel.Raise(new ChannelCreatedDomainEvent(channel.ChannelId));
        
        return channel;
    }

    public static Guid Delete(Channel channel)
    {
        channel.Raise(new ChannelDeletedDomainEvent(channel.ChannelId));
        return channel.ChannelId.Value;
    }

    public static Channel CreateUpdate(Guid id, ChannelId channelId, CampaignId campaignId, Title title, LaunchDate launchDate)
    {
        var channel = new Channel(id, channelId, campaignId, title, launchDate, new LastModified(DateTime.UtcNow), new Created(DateTime.UtcNow));
        
        channel.Raise(new ChannelUpdatedDomainEvent(channel.ChannelId));
        
        return channel;
    }
}