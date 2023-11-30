using Application.Contracts.Data;
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

    public static Domain.Tag ToTag(this TagDto tagDto)
    {
        return new Domain.Tag(Guid.Parse(tagDto.Id),
            new TagId(Guid.Parse(tagDto.TagId)),
            new CampaignId(Guid.Parse(tagDto.CampaignId)),
            new ChannelId(Guid.Parse(tagDto.ChannelId)),
            new Brand(tagDto.Brand),
            tagDto.Value,
            tagDto.Options,
            new LastModified(DateTime.Parse(tagDto.LastModified)),
            new Created(DateTime.Parse(tagDto.Created))
            );
    }
}