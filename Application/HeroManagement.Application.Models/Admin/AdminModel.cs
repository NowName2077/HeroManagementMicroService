using HeroManagement.Application.Models.Ability;
using HeroManagement.Application.Models.Base;
using HeroManagement.Application.Models.Hero;
using HeroManagement.Application.Models.Item;
using HeroManagement.Application.Models.Player;

namespace HeroManagement.Application.Models.Admin;

public record class AdminModel (Guid Id, string Username): UserModel(Id, Username)
{
    
}