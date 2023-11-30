using Domain.Common;

namespace Application.Contracts.Responses;

public class CampaignResponse
{
    public Guid Id { get; set; }
    public Guid CampaignId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public int TagStatus { get; set; }
    public IEnumerable<string> Tags { get; set; }

    public CampaignResponse(Guid id, Guid campaignId, string name, string status, int tagStatus, IEnumerable<string> tags)
    {
        Id = id;
        CampaignId = campaignId;
        Name = name;
        Status = status;
        TagStatus = tagStatus;
        Tags = tags;
    }
}