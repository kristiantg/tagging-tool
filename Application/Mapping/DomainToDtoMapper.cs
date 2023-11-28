using Application.Contracts.Campaign.Data;
using Domain.Campaign;

namespace Application.Mapping;

public static class DomainToDtoMapper
{
    public static CampaignDto ToCampaignDto(this Campaign campaign)
    {
        return new CampaignDto()
        {
            CampaignId = campaign.Id.ToString(),
            Title = campaign.Title.Value
        };
    }
}