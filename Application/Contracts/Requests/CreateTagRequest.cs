namespace Application.Contracts.Requests;

public record CreateTagRequest(Guid CampaignId, Guid ChannelId, string Key, string Brand, IEnumerable<string> Options);