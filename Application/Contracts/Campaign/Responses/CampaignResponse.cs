using Domain.Campaign;

namespace Application.Contracts.Campaign.Responses;

public class CampaignResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public CampaignResponse(Guid id, Title title)
    {
        Id = id;
        Name = title.Value;
    }
}