using Domain.Common;

namespace Application.Contracts.Campaign.Requests;

public record UpdateCampaignRequest(Guid CampaignId, string Name, string Status, int TagStatus, IEnumerable<Tag> Tags);