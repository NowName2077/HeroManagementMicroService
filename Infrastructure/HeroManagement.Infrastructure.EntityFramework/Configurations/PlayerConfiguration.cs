using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;
using HeroManagement.Domain.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroManagement.Infrastructure.EntityFramework.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Username)
            .IsRequired()
            .HasConversion(username => username.Value, str => new Username(str))
            .HasMaxLength(UsernameValidator.MAX_LENGTH);
        builder.HasIndex(x => x.Username).IsUnique();

        builder.HasMany(p => p.ObservableHeroes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>("PlayerHero",
                j => j.HasOne<Hero>().WithMany().HasForeignKey("HeroId"),
                j => j.HasOne<Player>().WithMany().HasForeignKey("PlayerId")
            );
        
        builder.HasMany(p => p.ObservableAbilities)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PlayerAbility",
                j => j.HasOne<Ability>().WithMany().HasForeignKey("AbilityId"),
                j => j.HasOne<Player>().WithMany().HasForeignKey("PlayerId")
            );
        
        builder.HasMany(p => p.ObservableItems)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PlayerItem",
                j => j.HasOne<Item>().WithMany().HasForeignKey("ItemId"),
                j => j.HasOne<Player>().WithMany().HasForeignKey("PlayerId")
            );
    }
}