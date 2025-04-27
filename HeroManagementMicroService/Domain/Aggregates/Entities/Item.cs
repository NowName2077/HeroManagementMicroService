using HeroManagementMicroService.Domain.Aggregates.Entities.Base;
using HeroManagementMicroService.Domain.ValueObjects;

namespace HeroManagementMicroService.Domain.Aggregates.Entities;

public class Item: Entity<Guid>
{
    public ObjectName ItemName { get; private set; }

    protected Item()
    {
        
    }
    protected Item(Guid id, ObjectName itemName) : base(id)
    {
        ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName));
    }
}