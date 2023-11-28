namespace Application.Contracts.Campaign.Requests;

public record UpdateCampaignRequest(Guid Guid, string Title, string Status, DateTime LaunchDate, bool TaggingCompleted, int ChannelsAmount, string Country, DateTime LastModified, bool IsPending, string Brand);