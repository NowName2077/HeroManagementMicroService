using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;
using HeroManagement.Domain.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroManagement.Infrastructure.EntityFramework.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Username)
            .IsRequired()
            .HasConversion(username => username.Value, str => new Username(str))
            .HasMaxLength(UsernameValidator.MAX_LENGTH);

        // builder.HasMany(a => a.ActiveHero)
        //     .WithOne();
        // builder.HasMany(p => p.ActiveAbility)
        //     .WithOne();
        // builder.HasMany(p => p.ActiveItem)
        //     .WithOne();
    }
}