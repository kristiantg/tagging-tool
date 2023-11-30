using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record TagCreatedDomainEvent(TagId Id) : IDomainEvent;