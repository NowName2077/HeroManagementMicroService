using HeroManagement.Application.Models.Ability;
using HeroManagement.Application.Models.Base;
using HeroManagement.Application.Models.Hero;
using HeroManagement.Application.Models.Item;

namespace HeroManagement.Application.Models.Admin;

public record class AdminModel (Guid Id, string Username): UserModel(Id, Username)
{
    public IEnumerable<ItemModel> Items { get; init; }
    public IEnumerable<HeroModel> Heroes { get; init; }
    public IEnumerable<AbilityModel> Abilities { get; init; }
}