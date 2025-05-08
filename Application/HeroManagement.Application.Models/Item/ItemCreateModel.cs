using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Item;

public record class ItemCreateModel(Guid Id, string ItemName) : ICreateModel;