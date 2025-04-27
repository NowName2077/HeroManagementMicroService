using HeroManagementMicroService.Domain.Aggregates.Entities;
namespace HeroManagementMicroService.Domain.Abstractions;

public interface IItemRepository : IRepository<Item, Guid>
{
    Task<Item?> GetItemByIdAsync(Guid id, CancellationToken cancellationToken);
}