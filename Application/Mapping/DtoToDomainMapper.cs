using Application.Contracts.Campaign.Data;
using Domain;
using Domain.Common;
using Domain.DomainEvents;

namespace Application.Mapping;

public static class DtoToDomainMapper
{
    public static Campaign ToCampaign(this CampaignDto campaignDto)
    {
        return new Campaign(Guid.Parse(campaignDto.Id),
            new CampaignId(Guid.Parse(campaignDto.CampaignId)),
            new Name(campaignDto.Name),
            new Status(campaignDto.Status),
            new TagStatus(campaignDto.TagStatus),
            new Tags(campaignDto.Tags),
            new LastModified(DateTime.Parse(campaignDto.LastModified)),
            new Created(DateTime.Parse(campaignDto.Created))
        );
    }

    public static Channel ToChannel(this ChannelDto channelDto)
    {
        return new Channel(Guid.Parse(channelDto.Id),
            new ChannelId(Guid.Parse(channelDto.ChannelId)),
            new CampaignId(Guid.Parse(channelDto.CampaignId)),
            new Title(channelDto.Title),
            new LaunchDate(DateTime.Parse(channelDto.LaunchDate)),
            new LastModified(DateTime.Parse(channelDto.LastModified)),
            new Created(DateTime.Parse(channelDto.Created)));
    }
}