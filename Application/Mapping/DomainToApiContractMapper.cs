using Application.Contracts.Responses;
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

    public static TagResponse ToTagResponse(this Tag tag)
    {
        return new TagResponse(tag.Id, tag.TagId.Value, tag.CampaignId.Value, tag.ChannelId.Value, tag.Options, tag.LastModified.Value, tag.Created.Value);
    }
}