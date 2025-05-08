using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Hero;

public record class HeroModel(Guid Id, string ItemName) : IModel<Guid>;