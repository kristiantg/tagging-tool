using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record CampaignDeletedDomainEvent(CampaignId Id) : IDomainEvent;