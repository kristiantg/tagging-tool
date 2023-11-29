using Domain.Abstractions;
using Domain.Common;

namespace Domain.DomainEvents;

public sealed record ChannelUpdatedDomainEvent(ChannelId Id) : IDomainEvent;