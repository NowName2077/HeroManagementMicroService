using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Admin;

public record class AdminCreateModel(Guid Id, string Username) : UserCreateModel(Id, Username);
