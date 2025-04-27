using HeroManagementMicroService.Domain.Aggregates.Entities;
namespace HeroManagementMicroService.Domain.Abstractions;

public interface IAbilityRepository : IRepository<Ability, Guid>
{
    Task<Ability?> GetAbilityByIdAsync(Guid id, CancellationToken cancellationToken);
}