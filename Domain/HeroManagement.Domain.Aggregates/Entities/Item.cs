using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Item : Entity<Guid>
{
    public ObjectName ItemName { get;}
    
    protected Item()
    {
        
    }
    protected Item(Guid id, ObjectName itemName) : base(id)
    {
        ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName));
        
    }

    public Item(ObjectName itemName) : this(Guid.NewGuid(), itemName)
    {
    }
    


}