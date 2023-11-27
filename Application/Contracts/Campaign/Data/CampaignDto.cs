using System.Text.Json.Serialization;

namespace Application.Contracts.Campaign.Data;

public class CampaignDto
{
    [JsonPropertyName("pk")]
    public string Pk => Id;

    [JsonPropertyName("sk")]
    public string Sk => Pk;
    
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;
}