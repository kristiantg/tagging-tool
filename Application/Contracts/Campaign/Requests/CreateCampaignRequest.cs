namespace Application.Contracts.Campaign.Requests;

public class CreateCampaignRequest
{
    public string Name { get; init; }

    public CreateCampaignRequest(string name)
    {
        Name = name;
    }
}