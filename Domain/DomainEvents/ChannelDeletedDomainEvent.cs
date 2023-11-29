using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record ChannelDeletedDomainEvent(ChannelId Id) : IDomainEvent;