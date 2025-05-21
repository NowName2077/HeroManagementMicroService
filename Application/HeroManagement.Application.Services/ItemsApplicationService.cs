
using AutoMapper;
using HeroManagement.Application.Models.Item;
using HeroManagement.Application.Services.Abstractions;
using HeroManagement.Domain.Abstractions;
using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Application.Services;

public class ItemsApplicationService(IItemsRepository itemRepository, IAdminsRepository adminsRepository, IMapper mapper) 
    : IItemApplicationService 
{
    public async Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken = default)
    => (await 
        itemRepository.GetAllAsync(cancellationToken, true)).Select(mapper.Map<ItemModel>);

    public async Task<ItemModel?> GetItemByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await itemRepository.GetByIdAsync(id, cancellationToken);
        return item is null ? null : mapper.Map<ItemModel>(item);
    }

    public async Task<ItemModel?> GetItemByObjectNameAsync(string objectName,
        CancellationToken cancellationToken = default)
    {
        var item = await itemRepository.GetItemByObjectNameAsync(objectName, cancellationToken);
        return item is null ? null : mapper.Map<ItemModel>(item);
    }

    public async Task<ItemModel?> CreateItemAsync(ItemCreateModel itemInformation, 
        CancellationToken cancellationToken = default)
    {

        
        if( await itemRepository.GetItemByObjectNameAsync(itemInformation.ObjectName, cancellationToken)is not null)
            return null;
        
        Item item = new (new ObjectName(itemInformation.ObjectName));
        
        var createdItem = await itemRepository.AddAsync(item, cancellationToken);
        return createdItem is null ? null : mapper.Map<ItemModel>(createdItem);
    }

    public async Task<bool> UpdateItemAsync(ItemModel item, CancellationToken cancellationToken = default)
    {
        var entity = await itemRepository.GetByIdAsync(item.Id, cancellationToken);
        if (entity is null) return false;
        
        entity = mapper.Map<Item>(item);
        return await itemRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteItemAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await itemRepository.GetByIdAsync(id, cancellationToken);
        return item is null ? false : await itemRepository.DeleteAsync(item, cancellationToken);
    }
}
