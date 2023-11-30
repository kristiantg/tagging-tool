using Domain.Abstractions;
using Domain.Common;
using Domain.DomainEvents;

namespace Domain;

public class Tag : Entity
{
    public TagId TagId { get; private set; }
    public CampaignId CampaignId { get; private set; }
    public ChannelId ChannelId { get; private set; }
    public Brand Brand { get; private set; }
    public string Value { get; private set; }
    public IEnumerable<string> Options { get; private set; }
    public LastModified LastModified { get; private set; }
    public Created Created { get; private set; }

    public Tag(Guid id, TagId tagId, CampaignId campaignId, ChannelId channelId, Brand brand, string value, IEnumerable<string> options, LastModified lastModified, Created created) : base(id)
    {
        TagId = tagId;
        CampaignId = campaignId;
        ChannelId = channelId;
        Brand = brand;
        Value = value;
        Options = options;
        LastModified = lastModified;
        Created = created;
    }

    public static Tag Create(CampaignId campaignId, ChannelId channelId, Brand brand, string value, IEnumerable<string> options)
    {
        var tag = new Tag(Guid.NewGuid(),
            new TagId(Guid.NewGuid()),
            campaignId,
            channelId,
            brand,
            value,
            options,
            new LastModified(DateTime.UtcNow),
            new Created(DateTime.UtcNow)
            );

        tag.Raise(new TagCreatedDomainEvent(tag.TagId));
        
        return tag;
    }
    
    public static Guid Delete(Tag tag)
    {
        tag.Raise(new TagDeletedDomainEvent(tag.TagId));
        return tag.TagId.Value;
    }
    
    public static Tag CreateUpdate(TagId tagId, CampaignId campaignId, ChannelId channelId, Brand brand, string value, IEnumerable<string> options, Created created)
    {
        var tag = new Tag(tagId.Value,
            tagId,
            campaignId,
            channelId,
            brand,
            value,
            options,
            new LastModified(DateTime.UtcNow),
            created
        );

        tag.Raise(new TagCreatedDomainEvent(tag.TagId));
        
        return tag;
    }
}