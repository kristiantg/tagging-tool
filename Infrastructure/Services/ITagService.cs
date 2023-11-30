using Domain;
using Domain.DomainEvents;

namespace Infrastructure.Services;

public interface ITagService
{
    Task<bool> CreateAsync(Tag tag);

    Task<Tag?> GetAsync(Guid id);

    Task<IEnumerable<Tag>> GetAllAsync();

    Task<bool> UpdateAsync(Tag channel);

    Task<bool> DeleteAsync(Guid id);
}