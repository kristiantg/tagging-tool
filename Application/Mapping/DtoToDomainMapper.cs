using Application.Contracts.Campaign.Data;
using Domain.Campaign;

namespace Application.Mapping;

public static class DtoToDomainMapper
{
    public static Campaign ToCampaign(this CampaignDto campaignDto)
    {
        return new Campaign(Guid.Parse(campaignDto.Id), new Name(campaignDto.Name));
    }
}