namespace Application.Contracts.Requests;

public record CreateChannelRequest(Guid CampaignId, string Title, DateTime LaunchDate);