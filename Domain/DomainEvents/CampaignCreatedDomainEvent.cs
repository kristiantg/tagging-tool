using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record CampaignCreatedDomainEvent(CampaignId Id) : IDomainEvent;