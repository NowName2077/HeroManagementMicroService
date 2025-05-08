using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Domain.Abstractions;

public interface IItemsRepository : IRepository<Item, Guid>
{
    Task<Item?> GetItemByIdAsync(Guid id, CancellationToken cancellationToken);
}