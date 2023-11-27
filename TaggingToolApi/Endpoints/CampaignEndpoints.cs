using Application.Contracts.Campaign.Requests;
using Application.Mapping;
using Domain.Campaign;
using Infrastructure.Services;

namespace TaggingToolApi.Endpoints;

public static class CampaignEndpoints
{
    public static void MapCampaignEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/campaigns", CreateCampaign)
            .WithName("CreateCampaign")
            .WithOpenApi();;
    }

    public static async Task<IResult> CreateCampaign(
        CreateCampaignRequest request, ICampaignService campaignService)
    {
        var campaign = Campaign.Create(
            new Name(request.Name)
            );

        await campaignService.CreateAsync(campaign);

        var campaignResponse = campaign.ToCampaignResponse();
        
        return Results.Ok(campaignResponse);
    }
}