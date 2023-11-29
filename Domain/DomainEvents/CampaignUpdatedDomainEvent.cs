using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record CampaignUpdatedDomainEvent(CampaignId Id) : IDomainEvent;