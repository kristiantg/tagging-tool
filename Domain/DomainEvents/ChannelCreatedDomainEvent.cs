using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record ChannelCreatedDomainEvent(ChannelId Id) : IDomainEvent;