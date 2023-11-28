using Application.Contracts.Campaign.Requests;
using Application.Mapping;
using Domain.Campaign;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaggingToolApi.Endpoints;

public static class CampaignEndpoints
{
    public static void MapCampaignEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/campaigns");
        
        group.MapPost("", CreateCampaign)
            .WithName("CreateCampaign")
            .WithOpenApi();
        
        group.MapGet("{guid}", GetCampaign)
            .WithName("GetCampaign")
            .WithOpenApi();
        
        group.MapPut("{guid}", UpdateCampaign)
            .WithName("UpdateCampaign")
            .WithOpenApi();
        
        group.MapDelete("{guid}", DeleteCampaign)
            .WithName("DeleteCampaign")
            .WithOpenApi();
    }
    
    private static async Task<IResult> CreateCampaign(
        [FromBody] CreateCampaignRequest request, ICampaignService campaignService)
    {
        var campaign = Campaign.Create(
            new Name(request.Name)
        );

        await campaignService.CreateAsync(campaign);

        var campaignResponse = campaign.ToCampaignResponse();
        
        return Results.Ok(campaignResponse);
    }

    private static async Task<IResult> GetCampaign(
        [FromRoute] Guid guid, ICampaignService campaignService)
    {
        var campaign = await campaignService.GetAsync(guid);

        if (campaign is null)
        {
            return Results.NotFound();
        }
        
        var campaignResponse = campaign.ToCampaignResponse();

        return Results.Ok(campaignResponse);
    }
    
    private static async Task<IResult> UpdateCampaign(
     [FromRoute] Guid guid, [FromBody] UpdateCampaignRequest request, ICampaignService campaignService)
    {
        var existingCampaign = await campaignService.GetAsync(guid);
        
        if (existingCampaign is null)
        {
            return Results.NotFound();
        }

        var campaign = Campaign.CreateUpdate(
            guid,
            new Name(request.Name)
        );
        
        await campaignService.UpdateAsync(campaign);

        var campaignResponse = campaign.ToCampaignResponse();

        return Results.Ok(campaignResponse);
    }
    
    private static async Task<IResult> DeleteCampaign(
        [FromRoute] Guid guid, ICampaignService campaignService)
    {
        var deleted = await campaignService.DeleteAsync(guid);

        if (!deleted)
        {
            return Results.NotFound();
        }

        return Results.Ok();
    }
}