using Domain.Common;

namespace Application.Contracts.Campaign.Requests;

public record CreateCampaignRequest(string Name, string Status, int TagStatus, IEnumerable<Tag> Tags);