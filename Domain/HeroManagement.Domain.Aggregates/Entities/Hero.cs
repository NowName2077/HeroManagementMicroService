using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Hero : Entity<Guid>
{
    public ObjectName HeroName { get; private set; }
    
    public Admin Admin { get; private set; }

    protected Hero()
    {

    }

    // protected Hero(Guid id, ObjectName heroName, Admin admin) : base(id)
    // {
    //     HeroName = heroName ?? throw new ArgumentNullException(nameof(heroName));
    //     
    //     Admin = admin ?? throw new ArgumentNullException(nameof(admin));
    // }
    
    public Hero(Guid id, ObjectName heroName, Admin admin)
    {
        HeroName = heroName ?? throw new ArgumentNullException(nameof(heroName));
        
        Admin = admin ?? throw new ArgumentNullException(nameof(admin));
    }
}