using HeroManagement.Application.Models.Ability;

namespace HeroManagement.Application.Services.Abstractions;

public interface IAbilityApplicationService
{
    Task<AbilityModel?> GetAbilityByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<AbilityModel?> GetAbilityByObjectNameAsync(string objectName, CancellationToken cancellationToken);

    Task<IEnumerable<AbilityModel>> GetAbilitiesAsync(CancellationToken cancellationToken);

    Task<AbilityModel?> CreateAbilityAsync(AbilityCreateModel abilityInformation, CancellationToken cancellationToken);

    Task<bool> UpdateAbilityAsync(AbilityModel ability, CancellationToken cancellationToken);

    Task<bool> DeleteAbilityAsync(Guid id, CancellationToken cancellationToken);
}