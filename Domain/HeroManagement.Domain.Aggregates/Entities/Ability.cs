using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Ability : Entity<Guid>
{
    public ObjectName AbilityName { get; private set; }
    
    public Admin Admin { get; private set; }

    protected Ability()
    {
        
    }
    // protected Ability(Guid id, ObjectName abilityName, Admin admin) : base(id)
    // {
    //     AbilityName = abilityName ?? throw new ArgumentNullException(nameof(abilityName));
    //     
    //     Admin = admin ?? throw new ArgumentNullException(nameof(admin));
    // }
    
    public Ability(Guid id, ObjectName abilityName, Admin admin)
    {
        AbilityName = abilityName ?? throw new ArgumentNullException(nameof(abilityName));
        
        Admin = admin ?? throw new ArgumentNullException(nameof(admin));
    }
}