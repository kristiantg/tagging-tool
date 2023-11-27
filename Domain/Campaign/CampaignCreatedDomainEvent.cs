using Domain.Abstractions;

namespace Domain.Campaign;

public sealed record CampaignCreatedDomainEvent(Guid Id) : IDomainEvent;