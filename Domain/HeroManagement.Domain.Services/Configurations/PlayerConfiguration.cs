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
        builder.HasMany(p => p.ObservableHeroes)
            .WithOne();
        builder.HasMany(p => p.ObservableAbilities)
            .WithOne();
        builder.HasMany(p => p.ObservableItems)
            .WithOne();
        //.HasForeignKey(h => h.Id);
    }
}