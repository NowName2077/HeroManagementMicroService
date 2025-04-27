using HeroManagementMicroService.Domain.Aggregates.Entities.Base;
using HeroManagementMicroService.Domain.Aggregates.Exceptions;
using HeroManagementMicroService.Domain.ValueObjects;

namespace HeroManagementMicroService.Domain.Aggregates.Entities;

public class Admin(Guid id, Username username): Entity<Guid>(id)
{
    private readonly ICollection<Player> _players = [];
    private readonly ICollection<Hero> _heroes = [];
    private readonly ICollection<Item> _items = [];
    private readonly ICollection<Ability> _abilities = [];
    
    public Username Username { get; private set; } =  username ?? throw new ArgumentNullValueException(nameof(username));
    
    internal bool ChangeUsername(Username newUsername)
    {
        if (Username == newUsername)
            return false;
        Username = newUsername;
        return true;
    }
}