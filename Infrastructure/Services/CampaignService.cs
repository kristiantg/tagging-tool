using Application.Mapping;
using Domain.Campaign;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class CampaignService : ICampaignService
{
    private readonly ICampaignRepository _campaignRepository;

    public CampaignService(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }

    public async Task<bool> CreateAsync(Campaign campaign)
    {
        var existingUser = await _campaignRepository.GetAsync(campaign.Id);
        
        if (existingUser is not null)
        {
            var message = $"A campaign with id {campaign.Id} already exists.";
        }
        
        var campaignDto = campaign.ToCampaignDto();
        
        return await _campaignRepository.CreateAsync(campaignDto);
    }

    public async Task<Campaign?> GetAsync(Guid id)
    {
        var campaignDto = await _campaignRepository.GetAsync(id);
        return campaignDto?.ToCampaign();
    }

    public Task<IEnumerable<Campaign>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Campaign campaign)
    {
        var campaignDto = campaign.ToCampaignDto();

        return await _campaignRepository.UpdateAsync(campaignDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _campaignRepository.DeleteAsync(id);
    }
}