using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.Aggregates.Exceptions;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Admin(Guid id, Username username): Entity<Guid>(id)
{
    // // private readonly ICollection<Player> _players = [];
    // private readonly ICollection<Hero> _heroes = [];
    // private readonly ICollection<Item> _items = [];
    // private readonly ICollection<Ability> _abilities = [];
    
    
    public Username Username { get; private set; } =  username ?? throw new ArgumentNullValueException(nameof(username));
    
    // public IReadOnlyCollection<Player> Players => _players;
    // public IReadOnlyCollection<Hero> ActiveHero => _heroes.ToList().AsReadOnly();
    // public IReadOnlyCollection<Item> ActiveItem => _items.ToList().AsReadOnly();
    // public IReadOnlyCollection<Ability> ActiveAbility => _abilities.ToList().AsReadOnly();
    
    internal bool ChangeUsername(Username newUsername)
    {
        if (Username == newUsername)
            return false;
        Username = newUsername;
        return true;
    }
    public Hero CreateAHero(ObjectName objectName) => new(objectName);
    public Item CreateAnItem(ObjectName objectName) => new(objectName);
    public Ability CreateAnAbility(ObjectName objectName) => new(objectName);
    
    // public Hero CreateAHero(ObjectName objectName)
    // {
    //     return new Hero(objectName);
    // }
    //
    // public Item CreateAnItem(ObjectName objectName)
    // {
    //    return new Item(objectName);
    // }
    // public Ability CreateAnAbility(ObjectName objectName)
    // {
    //     return new Ability(objectName);
    // }
}