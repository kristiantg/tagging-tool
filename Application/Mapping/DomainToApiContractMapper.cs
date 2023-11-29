using Application.Contracts.Campaign.Responses;
using Domain;

namespace Application.Mapping;

public static class DomainToApiContractMapper
{
    public static CampaignResponse ToCampaignResponse(this Campaign campaign)
    {
        return new CampaignResponse(campaign.Id, campaign.CampaignId.Value, campaign.Name.Value, campaign.Status.Value, campaign.TagStatus.Value, campaign.Tags.Value );
    }
}