using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Ability : Entity<Guid>
{
    public ObjectName AbilityName { get; private set; }
    
    public Guid PlayerId { get; set; }
    public Player Player { get; set; }
    
    //public Admin Admin { get; private set; }

    protected Ability()
    {
        
    }
    protected Ability(Guid id, ObjectName abilityName, Guid playerId, Player player) : base(id)
    {
        AbilityName = abilityName ?? throw new ArgumentNullException(nameof(abilityName));
    }
    
    public Ability(ObjectName abilityName, Guid playerId, Player player) : this(Guid.NewGuid(), abilityName, playerId, player)
    {

    }
}