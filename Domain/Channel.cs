using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public class Channel : Entity
{
    public ChannelId ChannelId { get; private set; }
    public CampaignId CampaignId { get; private set; }
    public Title Title { get; private set; }
    public LaunchDate LaunchDate { get; private set; }
    public Tags Tags { get; private set; }

    public Channel(Guid id, ChannelId channelId, CampaignId campaignId, Title title, LaunchDate launchDate, Tags tags) : base(id)
    {
        ChannelId = channelId;
        CampaignId = campaignId;
        Title = title;
        LaunchDate = launchDate;
        Tags = tags;
    }
}