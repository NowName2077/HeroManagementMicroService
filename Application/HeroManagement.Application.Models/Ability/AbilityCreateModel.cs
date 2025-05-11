using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Ability;

public record class AbilityCreateModel (Guid Id, string ObjectName, Guid AdminId) : ICreateModel;