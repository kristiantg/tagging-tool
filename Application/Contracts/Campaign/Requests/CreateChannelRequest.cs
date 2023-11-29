namespace Application.Contracts.Campaign.Requests;

public record CreateChannelRequest(Guid CampaignId, string Title, DateTime LaunchDate);