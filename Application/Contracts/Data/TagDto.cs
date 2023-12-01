using System.Text.Json.Serialization;
using Domain.Common;

namespace Application.Contracts.Data;

public class TagDto
{
    [JsonPropertyName("pk")]
    public string Pk => TagId;

    [JsonPropertyName("sk")]
    public string Sk => Pk;
    
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;
    
    [JsonPropertyName("campaignId")]
    public string CampaignId { get; init; } = default!;
    
    [JsonPropertyName("channelId")]
    public string ChannelId { get; init; } = default!;
    
    [JsonPropertyName("tagId")]
    public string TagId { get; init; } = default!;
    
    [JsonPropertyName("brand")]
    public string Brand { get; init; } = default!;
    
    [JsonPropertyName("value")]
    public string Value { get; init; } = default!;
    
    [JsonPropertyName("options")]
    public IEnumerable<string> Options { get; init; } = default!;
    
    [JsonPropertyName("lastModified")]
    public string LastModified { get; init; } = default!;
    
    [JsonPropertyName("created")]
    public string Created { get; init; } = default!;
}