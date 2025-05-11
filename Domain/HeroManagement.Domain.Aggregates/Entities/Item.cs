using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Item : Entity<Guid>
{
    public ObjectName ItemName { get;}

    public Admin Admin { get;}

    protected Item()
    {
        
    }
    // protected Item(Guid id, ObjectName itemName, Admin admin) : base(id)
    // {
    //     ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName));
    //     
    //     Admin = admin ?? throw new ArgumentNullException(nameof(admin));
    // }

    public Item(Guid id, ObjectName itemName, Admin admin)
    {
        ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName));
        Admin = admin ?? throw new ArgumentNullException(nameof(admin));
    }


}