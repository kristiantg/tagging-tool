using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record TagUpdatedDomainEvent(TagId Id) : IDomainEvent;