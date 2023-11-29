using Domain;

namespace Infrastructure.Services;

public interface ICampaignService
{
    Task<bool> CreateAsync(Campaign campaign);

    Task<Campaign?> GetAsync(Guid id);

    Task<IEnumerable<Campaign>> GetAllAsync();

    Task<bool> UpdateAsync(Campaign campaign);

    Task<bool> DeleteAsync(Guid id);
}