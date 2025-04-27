using HeroManagementMicroService.Domain.Aggregates.Entities;
namespace HeroManagementMicroService.Domain.Abstractions;

public interface IHeroRepository : IRepository<Hero, Guid>
{
    Task<Hero?> GetHeroByIdAsync(Guid id, CancellationToken cancellationToken);
}