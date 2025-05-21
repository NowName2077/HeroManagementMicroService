using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Hero;

public record class HeroModel(Guid Id, string ObjectName) : IModel<Guid>;