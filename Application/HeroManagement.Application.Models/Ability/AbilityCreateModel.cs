using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Ability;

public record class AbilityCreateModel (string ObjectName) : ICreateModel;