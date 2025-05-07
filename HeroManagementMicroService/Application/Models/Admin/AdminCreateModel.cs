using HeroManagementMicroService.Application.Models.Base;

namespace HeroManagementMicroService.Application.Models.Admin;

public record class AdminCreateModel(Guid Id, string Username) : UserCreateModel(Id, Username);