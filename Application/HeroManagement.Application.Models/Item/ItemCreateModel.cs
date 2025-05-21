using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Item;

public record class ItemCreateModel(string ObjectName) : ICreateModel;