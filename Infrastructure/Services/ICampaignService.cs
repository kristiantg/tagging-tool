namespace Infrastructure.Services;

public interface ICampaignService
{
    Task<bool> CreateAsync(Domain.Campaign.Campaign campaign);

    Task<Domain.Campaign.Campaign?> GetAsync(Guid id);

    Task<IEnumerable<Domain.Campaign.Campaign>> GetAllAsync();

    Task<bool> UpdateAsync(Domain.Campaign.Campaign campaign);

    Task<bool> DeleteAsync(Guid id);
}