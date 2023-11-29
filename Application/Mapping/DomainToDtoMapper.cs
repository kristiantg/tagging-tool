using Application.Contracts.Campaign.Data;
using Domain;

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
}