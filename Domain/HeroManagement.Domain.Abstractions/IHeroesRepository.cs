using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Domain.Abstractions;

public interface IHeroesRepository : IRepository<Hero, Guid>
{
    Task<Hero?> GetHeroByIdAsync(Guid id, CancellationToken cancellationToken);
}