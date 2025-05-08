using HeroManagement.Application.Models.Item;

namespace HeroManagement.Application.Services.Abstractions;

public interface IItemApplicationService
{
    Task<ItemModel?> GetItemByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<ItemModel?> GetItemByObjectNameAsync(string objectName, CancellationToken cancellationToken);

    Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken);

    Task<ItemModel?> CreateItemAsync(ItemCreateModel itemInformation, CancellationToken cancellationToken);

    Task<bool> UpdateItemAsync(ItemModel item, CancellationToken cancellationToken);

    Task<bool> DeleteItemAsync(Guid id, CancellationToken cancellationToken);
}