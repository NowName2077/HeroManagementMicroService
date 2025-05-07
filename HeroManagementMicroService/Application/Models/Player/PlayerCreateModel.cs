using HeroManagementMicroService.Application.Models.Base;

namespace HeroManagementMicroService.Application.Models.Player;

public record class PlayerCreateModel(Guid Id, string Username) : UserCreateModel(Id, Username);