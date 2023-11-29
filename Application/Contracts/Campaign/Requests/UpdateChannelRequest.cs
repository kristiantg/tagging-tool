namespace Application.Contracts.Campaign.Requests;

public record UpdateChannelRequest(Guid ChannelId, Guid CampaignId, string Title, DateTime LaunchDate);