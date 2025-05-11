using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Ability;

public record class AbilityModel(Guid Id, string ObjectName, Guid AdminId) : IModel<Guid>;