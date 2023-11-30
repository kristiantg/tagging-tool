using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record TagDeletedDomainEvent(TagId Id) : IDomainEvent;