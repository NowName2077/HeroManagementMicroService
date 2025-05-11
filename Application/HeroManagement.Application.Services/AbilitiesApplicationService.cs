using AutoMapper;
using HeroManagement.Application.Models.Ability;
using HeroManagement.Application.Services.Abstractions;
using HeroManagement.Domain.Abstractions;
using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Application.Services;

public class AbilitiesApplicationService (IAbilitiesRepository abilityRepository, IAdminsRepository adminsRepository, IMapper mapper) 
    : IAbilityApplicationService
{
    public async Task<IEnumerable<AbilityModel>> GetAbilitiesAsync(CancellationToken cancellationToken = default)
    => (await 
        abilityRepository.GetAllAsync(cancellationToken, true)).Select(mapper.Map<AbilityModel>);

    public async Task<AbilityModel?> GetAbilityByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ability = await abilityRepository.GetByIdAsync(id, cancellationToken);
        return ability is null ? null : mapper.Map<AbilityModel>(ability);
    }

    public async Task<AbilityModel?> GetAbilityByObjectNameAsync(string objectName,
        CancellationToken cancellationToken = default)
    {
        var ability = await abilityRepository.GetAbilityByObjectNameAsync(objectName, cancellationToken);
        return ability is null ? null : mapper.Map<AbilityModel>(ability);
    }

    public async Task<AbilityModel?> CreateAbilityAsync(AbilityCreateModel abilityInformation, CancellationToken cancellationToken)
    {
        var admin = await adminsRepository.GetByIdAsync(abilityInformation.AdminId, cancellationToken);
        if (admin is null) return null;
        
        if( await abilityRepository.GetByIdAsync(abilityInformation.Id, cancellationToken)is not null)
            return null;
        
        Ability ability = new (abilityInformation.Id, new(abilityInformation.ObjectName), admin);
        
        var createdAbility = await abilityRepository.AddAsync(ability, cancellationToken);
        return createdAbility is null ? null : mapper.Map<AbilityModel>(createdAbility);
    }

    public async Task<bool> UpdateAbilityAsync(AbilityModel ability, CancellationToken cancellationToken = default)
    {
        var entity = await abilityRepository.GetByIdAsync(ability.Id, cancellationToken);
        if (entity is null) return false;
        
        entity = mapper.Map<Ability>(ability);
        return await abilityRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteAbilityAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await abilityRepository.GetByIdAsync(id, cancellationToken);
        return item is null ? false : await abilityRepository.DeleteAsync(item, cancellationToken);
    }
}