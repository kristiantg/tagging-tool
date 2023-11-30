using Application.Contracts.Data;

namespace Infrastructure.Repositories;

public interface ICampaignRepository
{
    Task<bool> CreateAsync(CampaignDto campaign);

    Task<CampaignDto?> GetAsync(Guid id);

    Task<IEnumerable<CampaignDto>> GetAllAsync();

    Task<bool> UpdateAsync(CampaignDto campaign);

    Task<bool> DeleteAsync(Guid id);
}