using Application.Contracts.Campaign.Responses;
using Domain;
using Domain.DomainEvents;

namespace Application.Mapping;

public static class DomainToApiContractMapper
{
    public static CampaignResponse ToCampaignResponse(this Campaign campaign)
    {
        return new CampaignResponse(campaign.Id, campaign.CampaignId.Value, campaign.Name.Value, campaign.Status.Value, campaign.TagStatus.Value, campaign.Tags.Value );
    }

    public static ChannelResponse ToChannelResponse(this Channel channel)
    {
        return new ChannelResponse(channel.Id, channel.CampaignId.Value, channel.ChannelId.Value, channel.Title.Value, channel.LaunchDate.Value, channel.LastModified.Value, channel.Created.Value);
    }
}