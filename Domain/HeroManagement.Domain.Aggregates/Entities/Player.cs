using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.Aggregates.Exceptions;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Player(Guid id, Username username) : Entity<Guid>(id)
{
    private readonly ICollection<Hero> _observableHeroes = [];
    private readonly ICollection<Item> _observableItems = [];
    private readonly ICollection<Ability> _observableAbilities = [];

    public Username Username { get; private set; } = username ?? throw new ArgumentNullValueException(nameof(username));

    public IReadOnlyCollection<Hero> ObservableHeroes => _observableHeroes.ToList().AsReadOnly();
    public IReadOnlyCollection<Item> ObservableItems => _observableItems.ToList().AsReadOnly();
    public IReadOnlyCollection<Ability> ObservableAbilities => _observableAbilities.ToList().AsReadOnly();

    internal bool ChangeUsername(Username newUsername)
    {
        if (Username == newUsername)
            return false;
        Username = newUsername;
        return true;
    }
    
}
