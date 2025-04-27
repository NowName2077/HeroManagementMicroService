using HeroManagementMicroService.Domain.Aggregates.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HeroManagementMicroService.Infrastructure.EntityFramework.Configurations;

public class ItemConfiguration: IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        
    }
}