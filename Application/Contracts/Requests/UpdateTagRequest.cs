namespace Application.Contracts.Requests;

public record UpdateTagRequest(Guid TagId, Guid CampaignId, Guid ChannelId, string Key, string Brand, IEnumerable<string> Options);