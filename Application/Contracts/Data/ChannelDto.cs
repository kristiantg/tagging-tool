using System.Text.Json.Serialization;

namespace Application.Contracts.Data;

public class ChannelDto
{
    [JsonPropertyName("pk")]
    public string Pk => ChannelId;

    [JsonPropertyName("sk")]
    public string Sk => Pk;
    
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;
    
    [JsonPropertyName("campaignId")]
    public string CampaignId { get; init; } = default!;
    
    [JsonPropertyName("channelId")]
    public string ChannelId { get; init; } = default!;
    
    [JsonPropertyName("launchDate")]
    public string LaunchDate { get; init; } = default!;
    
    [JsonPropertyName("lastModified")]
    public string LastModified { get; init; } = default!;
    
    [JsonPropertyName("created")]
    public string Created { get; init; } = default!;
    
    [JsonPropertyName("title")]
    public string Title { get; init; } = default!;
}