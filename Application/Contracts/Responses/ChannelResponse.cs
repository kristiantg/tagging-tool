namespace Application.Contracts.Responses;

public class ChannelResponse
{
    public Guid Id { get; set; }
    public Guid CampaignId { get; set; }
    public Guid ChannelId { get; set; }
    public string Title { get; set; }
    public DateTime LaunchDate { get; set; }
    public DateTime LastModified { get; set; }
    public DateTime Created { get; set; }

    public ChannelResponse(Guid id, Guid campaignId, Guid channelId, string title, DateTime launchDate, DateTime lastModified, DateTime created)
    {
        Id = id;
        CampaignId = campaignId;
        ChannelId = channelId;
        Title = title;
        LaunchDate = launchDate;
        LastModified = lastModified;
        Created = created;
    }
}