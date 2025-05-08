using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Domain.Abstractions;

public interface IAbilitiesRepository : IRepository<Ability, Guid>
{
    Task<Ability?> GetAbilityByIdAsync(Guid id, CancellationToken cancellationToken);
}