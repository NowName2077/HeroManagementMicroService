using AutoMapper;
using HeroManagement.Application.Models.Hero;
using HeroManagement.Application.Services.Abstractions;
using HeroManagement.Domain.Abstractions;
using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Application.Services;


public class HerosApplicationService (IHeroesRepository heroRepository, IAdminsRepository adminsRepository, IMapper mapper) 
    : IHeroApplicationService
{
    public async Task<IEnumerable<HeroModel>> GetHeroesAsync(CancellationToken cancellationToken = default)
    => (await 
        heroRepository.GetAllAsync(cancellationToken, true)).Select(mapper.Map<HeroModel>);

    public async Task<HeroModel?> GetHeroByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var hero = await heroRepository.GetByIdAsync(id, cancellationToken);
        return hero is null ? null : mapper.Map<HeroModel>(hero);
    }

    public async Task<HeroModel?> GetHeroByObjectNameAsync(string objectName,
        CancellationToken cancellationToken = default)
    {
        var hero = await heroRepository.GetHeroByObjectNameAsync(objectName, cancellationToken);
        return hero is null ? null : mapper.Map<HeroModel>(hero);
    }

    public async Task<HeroModel?> CreateHeroAsync(HeroCreateModel heroInformation, 
        CancellationToken cancellationToken = default)
    {

        if( await heroRepository.GetHeroByObjectNameAsync(heroInformation.ObjectName, cancellationToken)is not null)
            return null;
        
        Hero hero = new (new ObjectName(heroInformation.ObjectName));
        
        var createdHero = await heroRepository.AddAsync(hero, cancellationToken);
        return createdHero is null ? null : mapper.Map<HeroModel>(createdHero);
    }

    public async Task<bool> UpdateHeroAsync(HeroModel hero, CancellationToken cancellationToken = default)
    {
        var entity = await heroRepository.GetByIdAsync(hero.Id, cancellationToken);
        if (entity is null) return false;
        
        entity = mapper.Map<Hero>(hero);
        return await heroRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteHeroAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var hero = await heroRepository.GetByIdAsync(id, cancellationToken);
        return hero is null ? false : await heroRepository.DeleteAsync(hero, cancellationToken);
    }
}