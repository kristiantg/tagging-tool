using Domain.Abstractions;

namespace Domain.Campaign;

public sealed record CampaignUpdatedDomainEvent(Guid Id) : IDomainEvent;