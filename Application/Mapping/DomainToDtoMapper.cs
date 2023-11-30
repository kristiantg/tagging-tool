using Application.Contracts.Data;
using Domain;
using Domain.DomainEvents;

namespace Application.Mapping;

public static class DomainToDtoMapper
{
    public static CampaignDto ToCampaignDto(this Campaign campaign)
    {
        return new CampaignDto()
        {
            Id = campaign.Id.ToString(),
            CampaignId = campaign.CampaignId.Value.ToString(),
            LastModified = campaign.LastModified.Value.ToShortDateString(),
            Created = campaign.Created.Value.ToShortDateString(),
            Name = campaign.Name.Value,
            TagStatus = campaign.TagStatus.Value,
            Tags = campaign.Tags.Value,
            Status = campaign.Status.Value
        };
    }

    public static ChannelDto ToChannelDto(this Channel channel)
    {
        return new ChannelDto()
        {
            Id = channel.Id.ToString(),
            CampaignId = channel.CampaignId.Value.ToString(),
            ChannelId = channel.ChannelId.Value.ToString(),
            Title = channel.Title.Value,
            LaunchDate = channel.LaunchDate.Value.ToShortDateString()
        };
    }

    public static TagDto ToTagDto(this Tag tag)
    {
        return new TagDto()
        {
            Id = tag.Id.ToString(),
            CampaignId = tag.CampaignId.Value.ToString(),
            ChannelId = tag.ChannelId.Value.ToString(),
            Brand = tag.Brand.Value,
            Created = tag.Created.Value.ToShortDateString(),
            LastModified = tag.LastModified.Value.ToShortDateString(),
            Options = tag.Options,
            TagId = tag.Id.ToString()
        };
    }
}