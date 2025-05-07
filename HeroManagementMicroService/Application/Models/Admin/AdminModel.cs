using HeroManagementMicroService.Application.Models.Base;
using HeroManagementMicroService.Application.Models.Hero;

namespace HeroManagementMicroService.Application.Models.Admin;

public record class AdminModel(Guid Id, string Username): UserModel(Id, Username)
{

}