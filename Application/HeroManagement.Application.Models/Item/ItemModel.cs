using HeroManagement.Application.Models.Base;

namespace HeroManagement.Application.Models.Item;

public record class ItemModel(Guid Id, string ObjectName, Guid AdminId) : IModel<Guid>;
