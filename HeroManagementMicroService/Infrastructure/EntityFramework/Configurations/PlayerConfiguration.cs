using HeroManagementMicroService.Domain.Aggregates.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroManagementMicroService.Infrastructure.EntityFramework.Configurations;

public class PlayerConfiguration: IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        
    }
}