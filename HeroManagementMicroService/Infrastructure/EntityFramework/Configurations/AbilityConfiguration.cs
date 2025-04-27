using HeroManagementMicroService.Domain.Aggregates.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroManagementMicroService.Infrastructure.EntityFramework.Configurations;

public class AbilityConfiguration: IEntityTypeConfiguration<Ability>
{
    public void Configure(EntityTypeBuilder<Ability> builder)
    {
        
    }
}