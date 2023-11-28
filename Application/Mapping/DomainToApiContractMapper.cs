using Application.Contracts.Campaign.Responses;
using Domain.Campaign;

namespace Application.Mapping;

public static class DomainToApiContractMapper
{
    public static CampaignResponse ToCampaignResponse(this Campaign campaign)
    {
        return new CampaignResponse(campaign.Id, campaign.Title);
    }
}