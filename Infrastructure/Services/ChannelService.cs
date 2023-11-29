using Application.Mapping;
using Domain;
using Domain.DomainEvents;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ChannelService : IChannelService
{
    private readonly IChannelRepository _channelRepository;

    public ChannelService(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<bool> CreateAsync(Channel channel)
    {
        var existingChannel = await _channelRepository.GetAsync(channel.ChannelId.Value);
        
        if (existingChannel is not null)
        {
            var message = $"A channel with id {channel.ChannelId} already exists.";
        }
        
        var channelDto = channel.ToChannelDto();
        
        return await _channelRepository.CreateAsync(channelDto);
    }

    public async Task<Channel?> GetAsync(Guid id)
    {
        var channelDto = await _channelRepository.GetAsync(id);
        return channelDto?.ToChannel();
    }

    public Task<IEnumerable<Channel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Channel channel)
    {
        var channelDto = channel.ToChannelDto();
        
        return await _channelRepository.UpdateAsync(channelDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _channelRepository.DeleteAsync(id);
    }
}