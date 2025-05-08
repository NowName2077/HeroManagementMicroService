using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Ability;

public record class AbilityModel(Guid Id, string ItemName) : IModel<Guid>;