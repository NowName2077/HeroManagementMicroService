using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Player;

public record class PlayerCreateModel(Guid Id, string Username) : UserCreateModel(Id, Username);
