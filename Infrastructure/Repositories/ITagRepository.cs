using Application.Contracts.Data;

namespace Infrastructure.Repositories;

public interface ITagRepository
{
    Task<bool> CreateAsync(TagDto tag);

    Task<TagDto?> GetAsync(Guid id);

    Task<bool> UpdateAsync(TagDto tag);

    Task<bool> DeleteAsync(Guid id);
}