using Application.Contracts.Campaign.Data;
using Domain.Campaign;
using Domain.Campaign.Common;

namespace Application.Mapping;

public static class DtoToDomainMapper
{
    public static Campaign ToCampaign(this CampaignDto campaignDto)
    {
        return new Campaign(Guid.Parse(campaignDto.CampaignId), 
            new Title(campaignDto.Title),
            new Status(campaignDto.Status),
            new LaunchDate(campaignDto.LaunchDate),
            new TaggingCompleted(campaignDto.TaggingCompleted),
            new ChannelsAmount(campaignDto.ChannelsAmount),
            new Country(campaignDto.Country),
            new LastModified(),
            new IsPending(campaignDto.IsPending),
            new Brand(campaignDto.Brand)
            );
    }
}