using System.Text.Json.Serialization;
using Domain.Common;

namespace Application.Contracts.Data;
public class CampaignDto
{
    [JsonPropertyName("pk")]
    public string Pk => CampaignId;

    [JsonPropertyName("sk")]
    public string Sk => Pk;
    
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;
    
    [JsonPropertyName("campaignId")]
    public string CampaignId { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;
    
    [JsonPropertyName("status")]
    public string Status { get; init; } = default!;
    
    [JsonPropertyName("lastModified")]
    public string LastModified { get; init; } = default!;
    
    [JsonPropertyName("created")]
    public string Created { get; init; } = default!;
    
    [JsonPropertyName("tagStatus")]
    public int TagStatus { get; init; } = default!;
    
    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; init; } = default!;

}