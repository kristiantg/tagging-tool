namespace Application.Contracts.Requests;

public record UpdateChannelRequest(Guid ChannelId, IEnumerable<string> Tags, string Title, DateTime LaunchDate);