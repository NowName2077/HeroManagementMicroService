
using AutoMapper;
using HeroManagement.Application.Models.Item;
using HeroManagement.Application.Services.Abstractions;
using HeroManagement.Domain.Abstractions;

namespace HeroManagement.Application.Services;

public class ItemsApplicationService(IItemsRepository repository, IMapper mapper) : IItemApplicationService 
{
    public async Task<IEnumerable<ItemModel>> GetItemsAsync(CancellationToken cancellationToken = default)
    => (await repository.GetAllAsync(cancellationToken, true)).Select(mapper.Map<ItemModel>);

    public async Task<ItemModel?> GetItemByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await repository.GetByIdAsync(id, cancellationToken);
        return item is null ? null : mapper.Map<ItemModel>(item);
    }

    public async Task<ItemModel?> GetItemByObjectNameAsync(string objectName,
        CancellationToken cancellationToken = default)
    {
        
    }
    public async Task<>
    public async Task<>
    public async Task<>
}