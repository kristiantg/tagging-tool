using Application.Contracts.Campaign.Requests;
using Application.Mapping;
using Domain;
using Domain.Common;
using Domain.DomainEvents;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaggingToolApi.Endpoints;

public static class ChannelEndpoints
{
    public static void MapChannelEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/channels");
        
        group.MapPost("", CreateChannel)
            .WithName(nameof(CreateChannel))
            .WithOpenApi();
        
        group.MapGet("{guid}", GetChannel)
            .WithName(nameof(GetChannel))
            .WithOpenApi();
        
        group.MapPut("{guid}", UpdateChannel)
            .WithName(nameof(UpdateChannel))
            .WithOpenApi();
        
        group.MapDelete("{guid}", DeleteChannel)
            .WithName(nameof(DeleteChannel))
            .WithOpenApi();
    }
    
    private static async Task<IResult> CreateChannel(
        [FromBody] CreateChannelRequest request, IChannelService channelService, ICampaignService campaignService)
    {
        var campaign = await campaignService.GetAsync(request.CampaignId);

        if (campaign is null)
        {
            return Results.NotFound();
        }
        
        var channel = Channel.Create(
            new CampaignId(request.CampaignId),
            new Title(request.Title),
            new LaunchDate(request.LaunchDate)
        );

        await channelService.CreateAsync(channel);

        var campaignResponse = channel.ToChannelResponse();
        
        return Results.Ok(campaignResponse);
    }

    private static async Task<IResult> GetChannel(
        [FromRoute] Guid guid, IChannelService channelService)
    {
        var channel = await channelService.GetAsync(guid);

        if (channel is null)
        {
            return Results.NotFound();
        }
        
        var campaignResponse = channel.ToChannelResponse();

        return Results.Ok(campaignResponse);
    }
    
    private static async Task<IResult> UpdateChannel(
     [FromRoute] Guid guid, [FromBody] UpdateChannelRequest request, IChannelService channelService, ICampaignService campaignService)
    {
        var existingChannel = await channelService.GetAsync(guid);
        
        if (existingChannel is null)
        {
            return Results.NotFound();
        }
        
        var campaign = await campaignService.GetAsync(request.CampaignId);

        if (campaign is null)
        {
            return Results.NotFound();
        }

        var channel = Channel.CreateUpdate(
             guid,
             new ChannelId(request.ChannelId),
             new CampaignId(request.CampaignId),
             new Title(request.Title),
             new LaunchDate(request.LaunchDate)
            );
        
        await channelService.UpdateAsync(channel);

        var campaignResponse = channel.ToChannelResponse();

        return Results.Ok(campaignResponse);
    }
    
    private static async Task<IResult> DeleteChannel(
        [FromRoute] Guid guid, IChannelService channelService)
    {
        var deleted = await channelService.DeleteAsync(guid);

        if (!deleted)
        {
            return Results.NotFound();
        }

        return Results.Ok();
    }
}