using Application.Contracts.Requests;
using Application.Mapping;
using Domain;
using Domain.Common;
using Domain.DomainEvents;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Tag = Domain.Tag;

namespace TaggingToolApi.Endpoints;

public static class TagEndpoints
{
    public static void MapTagEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/tags");
        
        group.MapPost("", CreateTag)
            .WithName(nameof(CreateTag))
            .WithOpenApi();
        
        group.MapGet("{guid}", GetTag)
            .WithName(nameof(GetTag))
            .WithOpenApi();
        
        group.MapPut("{guid}", UpdateTag)
            .WithName(nameof(UpdateTag))
            .WithOpenApi();
        
        group.MapDelete("{guid}", DeleteTag)
            .WithName(nameof(DeleteTag))
            .WithOpenApi();
    }
    
    private static async Task<IResult> CreateTag(
        [FromBody] CreateTagRequest request, ITagService tagService, IChannelService channelService, ICampaignService campaignService)
    {
        var campaign = await campaignService.GetAsync(request.CampaignId);

        if (campaign is null)
        {
            return Results.NotFound("Campaign does not exist");
        }
        
        var channel = await channelService.GetAsync(request.ChannelId);

        if (channel is null)
        {
            return Results.NotFound("Channel does not exist.");
        }
        
        var tag = Tag.Create(
                new CampaignId(request.CampaignId),
                new ChannelId(request.ChannelId),
                new Brand(request.Brand),
                request.Key,
                request.Options
            );

        await tagService.CreateAsync(tag);

        var tagResponse = tag.ToTagResponse();
        
        return Results.Ok(tagResponse);
    }

    private static async Task<IResult> GetTag(
        [FromRoute] Guid guid, ITagService tagService)
    {
        var tag = await tagService.GetAsync(guid);

        if (tag is null)
        {
            return Results.NotFound();
        }
        
        var tagResponse = tag.ToTagResponse();

        return Results.Ok(tagResponse);
    }
    
    private static async Task<IResult> UpdateTag(
     [FromRoute] Guid guid, [FromBody] UpdateTagRequest request, ITagService tagService, IChannelService channelService, ICampaignService campaignService)
    {
        var existingTag = await tagService.GetAsync(guid);
        
        if (existingTag is null)
        {
            return Results.NotFound("Tag does not exist.");
        }
        
        var campaign = await campaignService.GetAsync(request.CampaignId);

        if (campaign is null)
        {
            return Results.NotFound("Campaign does not exist.");
        }
        
        var channel = await channelService.GetAsync(request.ChannelId);

        if (channel is null)
        {
            return Results.NotFound("Channel does not exist.");
        }

        var tag = Tag.CreateUpdate(
             existingTag.TagId,
             new CampaignId(request.CampaignId),
             new ChannelId(request.ChannelId),
             new Brand(request.Brand),
             request.Key,
             request.Options,
             existingTag.Created
            );
        
        await tagService.UpdateAsync(tag);

        var tagResponse = tag.ToTagResponse();

        return Results.Ok(tagResponse);
    }
    
    private static async Task<IResult> DeleteTag(
        [FromRoute] Guid guid, ITagService tagService)
    {
        var deleted = await tagService.DeleteAsync(guid);

        if (!deleted)
        {
            return Results.NotFound();
        }

        return Results.Ok();
    }
}