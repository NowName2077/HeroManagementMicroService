using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Ability : Entity<Guid>
{
    public ObjectName AbilityName { get; private set; }
    protected Ability()
    {
        
    }
    protected Ability(Guid id, ObjectName abilityName) : base(id)
    {
        AbilityName = abilityName ?? throw new ArgumentNullException(nameof(abilityName));
    }
    
    public Ability(ObjectName abilityName) : this(Guid.NewGuid(), abilityName)
    {

    }
}