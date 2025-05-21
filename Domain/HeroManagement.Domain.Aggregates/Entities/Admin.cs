using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.Aggregates.Exceptions;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Admin(Guid id, Username username): Entity<Guid>(id)
{
    // private readonly ICollection<Player> _players = [];
    private readonly ICollection<Hero> _heroes = [];
    private readonly ICollection<Item> _items = [];
    private readonly ICollection<Ability> _abilities = [];
    
    
    public Username Username { get; private set; } =  username ?? throw new ArgumentNullValueException(nameof(username));
    
    // public IReadOnlyCollection<Player> Players => _players;
    public IReadOnlyCollection<Hero> ActiveHero => _heroes.ToList().AsReadOnly();
    public IReadOnlyCollection<Item> ActiveItem => _items.ToList().AsReadOnly();
    public IReadOnlyCollection<Ability> ActiveAbility => _abilities.ToList().AsReadOnly();
    
    internal bool ChangeUsername(Username newUsername)
    {
        if (Username == newUsername)
            return false;
        Username = newUsername;
        return true;
    }

    public Hero CreateAHero(ObjectName objectName)
    {
        var hero = new Hero(objectName);
        _heroes.Add(hero);
        return hero;
    }

    // public bool UpdateAHero(ObjectName newObjectName)
    // {
    //     var hero = _heroes.FirstOrDefault(h => h.Id == id);
    //     if (hero.HeroName == newObjectName)
    //         return false;
    //     hero.HeroName = newObjectName;
    //     return true;
    // }
    
    public Item CreateAnItem(ObjectName objectName)
    {
        var item = new Item(objectName);
        _items.Add(item);
        return item;
    }
    public Ability CreateAnAbility(ObjectName objectName, Guid playerId, Player player)
    {
        var ability = new Ability(objectName, playerId, player);
        _abilities.Add(ability);
        return ability;
    }
}