using System.Text.Json.Serialization;

namespace Application.Contracts.Campaign.Data;

public class CampaignDto
{
    [JsonPropertyName("pk")]
    public string Pk => CampaignId;

    [JsonPropertyName("sk")]
    public string Sk => Pk;
    
    [JsonPropertyName("campaignId")]
    public string CampaignId { get; init; } = default!;

    [JsonPropertyName("title")]
    public string Title { get; init; } = default!;
    
    [JsonPropertyName("status")]
    public string Status { get; init; } = default!;
    
    [JsonPropertyName("launchDate")]
    public DateTime LaunchDate { get; init; } = default!;
    
    [JsonPropertyName("taggingCompleted")]
    public bool TaggingCompleted { get; init; } = default!;
    
    [JsonPropertyName("channelsAmount")]
    public int ChannelsAmount { get; init; } = default!;
    
    [JsonPropertyName("country")]
    public string Country { get; init; } = default!;
    
    [JsonPropertyName("lastModified")]
    public DateTime LastModified { get; init; } = default!;
    
    [JsonPropertyName("isPending")]
    public bool IsPending { get; init; } = default!;
    
    [JsonPropertyName("brand")]
    public string Brand { get; init; } = default!;
}