using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Hero : Entity<Guid>
{
    public ObjectName HeroName { get; private set; }
    

    protected Hero()
    {

    }

    protected Hero(Guid id, ObjectName heroName) : base(id)
     {
         HeroName = heroName ?? throw new ArgumentNullException(nameof(heroName));
     }
    
    public Hero(ObjectName heroName) : this(Guid.NewGuid(), heroName)
    {
        
        
    }
}