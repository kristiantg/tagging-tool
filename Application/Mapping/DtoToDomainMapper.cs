using Application.Contracts.Campaign.Data;
using Domain;
using Domain.Common;

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
}