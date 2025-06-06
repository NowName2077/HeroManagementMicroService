﻿using HeroManagementMicroService.Domain.Aggregates.Entities.Base;
using HeroManagementMicroService.Domain.ValueObjects;

namespace HeroManagementMicroService.Domain.Aggregates.Entities;

public class Hero: Entity<Guid>
{
    public ObjectName HeroName { get; private set; }

    protected Hero()
    {
        
    }
    protected Hero(Guid id, ObjectName heroName) : base(id)
    {
        HeroName = heroName ?? throw new ArgumentNullException(nameof(heroName));
    }
}