using Application.Contracts.Data;

namespace Infrastructure.Repositories;

public interface IChannelRepository
{
    Task<bool> CreateAsync(ChannelDto channel);

    Task<ChannelDto?> GetAsync(Guid id);

    Task<bool> UpdateAsync(ChannelDto channel);

    Task<bool> DeleteAsync(Guid id);
}