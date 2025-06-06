using HeroManagement.Domain.Aggregates.Entities.Base;
using HeroManagement.Domain.Aggregates.Exceptions;
using HeroManagement.Domain.ValueObjects;

namespace HeroManagement.Domain.Aggregates.Entities;

public class Admin(Guid id, Username username): Entity<Guid>(id)
{
    public Username Username { get; private set; } =  username ?? throw new ArgumentNullValueException(nameof(username));
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
}