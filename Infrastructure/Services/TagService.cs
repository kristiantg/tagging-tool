using Application.Mapping;
using Domain;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<bool> CreateAsync(Tag tag)
    {
        var existingTag = await _tagRepository.GetAsync(tag.TagId.Value);
        
        if (existingTag is not null)
        {
            var message = $"A tag with id {tag.TagId} already exists.";
        }
        
        var tagDto = tag.ToTagDto();
        
        return await _tagRepository.CreateAsync(tagDto);
    }

    public async Task<Tag?> GetAsync(Guid id)
    {
        var tagDto = await _tagRepository.GetAsync(id);
        return tagDto?.ToTag();
    }

    public Task<IEnumerable<Tag>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Tag tag)
    {
        var tagDto = tag.ToTagDto();
        
        return await _tagRepository.UpdateAsync(tagDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _tagRepository.DeleteAsync(id);
    }
}