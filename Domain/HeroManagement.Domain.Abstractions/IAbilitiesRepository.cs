using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Domain.Abstractions;

public interface IAbilitiesRepository : IRepository<Ability, Guid>
{
    Task<Ability?> GetAbilityByObjectNameAsync(string objectName, CancellationToken cancellationToken);
}