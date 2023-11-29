using Application.Contracts.Campaign.Data;
using Domain;

namespace Application.Mapping;

public static class DomainToDtoMapper
{
    public static CampaignDto ToCampaignDto(this Campaign campaign)
    {
        return new CampaignDto()
        {
            CampaignId = campaign.CampaignId.ToString(),
            Title = campaign.Title.Value
        };
    }
}