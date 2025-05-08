using HeroManagement.Application.Models.Hero;

namespace HeroManagement.Application.Services.Abstractions;

public interface IHeroApplicationService
{
    Task<HeroModel?> GetHeroByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<HeroModel?> GetHeroByObjectNameAsync(string objectName, CancellationToken cancellationToken);

    Task<IEnumerable<HeroModel>> GetHeroesAsync(CancellationToken cancellationToken);

    Task<HeroModel?> CreateHeroAsync(HeroCreateModel heroInformation, CancellationToken cancellationToken);

    Task<bool> UpdateHeroAsync(HeroModel hero, CancellationToken cancellationToken);

    Task<bool> DeleteHeroAsync(Guid id, CancellationToken cancellationToken);
}                      