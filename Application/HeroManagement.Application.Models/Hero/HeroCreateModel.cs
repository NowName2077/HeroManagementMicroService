using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Hero;

public record class HeroCreateModel(string ObjectName) : ICreateModel;