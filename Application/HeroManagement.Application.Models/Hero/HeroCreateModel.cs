using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Hero;

public record class HeroCreateModel(Guid Id, string ObjectName, Guid AdminId) : ICreateModel;