namespace Application.Contracts.Campaign.Requests;

public record CreateCampaignRequest(string Title, string Status, DateTime LaunchDate, bool TaggingCompleted, int ChannelsAmount, string Country, DateTime LastModified, bool IsPending, string Brand);