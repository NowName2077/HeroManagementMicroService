using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Domain.Abstractions;

public interface IHeroesRepository : IRepository<Hero, Guid>
{
    Task<Item?> GetHeroByObjectNameAsync(string objectName, CancellationToken cancellationToken);
}