using HeroManagementMicroService.Application.Models.Base;
using HeroManagementMicroService.Application.Models.Hero;

namespace HeroManagementMicroService.Application.Models.Player;

public record class PlayerModel(Guid Id, string Username): UserModel(Id, Username)
{

}