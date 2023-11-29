using Domain;
using Domain.DomainEvents;

namespace Infrastructure.Services;

public interface IChannelService
{
    Task<bool> CreateAsync(Channel channel);

    Task<Channel?> GetAsync(Guid id);

    Task<IEnumerable<Channel>> GetAllAsync();

    Task<bool> UpdateAsync(Channel channel);

    Task<bool> DeleteAsync(Guid id);
}