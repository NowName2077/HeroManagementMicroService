using HeroManagementMicroService.Domain.Aggregates.Entities.Base;
using HeroManagementMicroService.Domain.ValueObjects;

namespace HeroManagementMicroService.Domain.Aggregates.Entities;

public class Ability: Entity<Guid>
{
    public ObjectName AbilityName { get; private set; }

    protected Ability()
    {
        
    }
    protected Ability(Guid id, ObjectName abilityName) : base(id)
    {
        AbilityName = abilityName ?? throw new ArgumentNullException(nameof(abilityName));
    }
}