using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Domain.Abstractions;

public interface IItemsRepository : IRepository<Item, Guid>
{
    Task<Item?> GetItemByObjectNameAsync(string objectName, CancellationToken cancellationToken);
}