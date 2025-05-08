using HeroManagement.Application.Models.Ability;
using HeroManagement.Application.Models.Base;
using HeroManagement.Application.Models.Hero;
using HeroManagement.Application.Models.Item;

namespace HeroManagement.Application.Models.Player;

public record class PlayerModel (Guid Id, string Username): UserModel(Id, Username)
{
    public IEnumerable<ItemModel> ObservedItems { get; init; }
    public IEnumerable<HeroModel> ObservedHeroes { get; init; }
    public IEnumerable<AbilityModel> ObservedAbilities { get; init; }
}